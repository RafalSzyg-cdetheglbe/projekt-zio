﻿using NuGet.Protocol.Plugins;
using System.Linq;
using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.UserEntities;
using WebApi.Models.DTO;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class UserService : IUserInterface
    {
        private readonly MeteoContext _dbContext;
        public UserService(MeteoContext meteoContext)
        {
            this._dbContext = meteoContext;
        }

        public int AddUser(UserDTO userRequestDTO)
        {
            if (userRequestDTO != null)
                return CreateUserWithAuditData(userRequestDTO);
            return -1;
        }

        private UserAudit CreateDefaultAudit()
        {
            var audit = new UserAudit() { CreatedAt = DateTime.Now, LastLoginAt = null, UpdatedAt = DateTime.Now };
            _dbContext.Add(audit);
            _dbContext.SaveChanges();
            return audit;
        }

        private int CreateUserWithAuditData(UserDTO userRequestDTO)
        {
            var checkIfExists = this._dbContext.Users?.FirstOrDefault(x => x.Login == userRequestDTO.Login || x.Name == userRequestDTO.Name);
            if (checkIfExists != null)
                throw new Exception("Użytkownik z takimi danymi logowania już istnieje na bazie danych");

            var audit = CreateDefaultAudit();
            var user = new User(userRequestDTO);
            user.UserAudit = audit;
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public bool DeleteUser(int userId)
        {
            var user = _dbContext.Users?.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                if (user.UserAudit != null)
                {
                    var audit = user.UserAudit;
                    user.UserAudit = null;
                    _dbContext.Remove(audit);
                }
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public UserDTO GetUser(int userId)
        {
            var user = _dbContext.Users?.FirstOrDefault(x => x.Id == userId);
            if (user != null)
                return new UserDTO(user);
            return null;
        }

        public List<UserDTO> GetUsers()
        {
            if (_dbContext.Users == null || _dbContext.Users.Count() == 0)
                return new List<UserDTO>();
            else
                return _dbContext.Users.Select(x => new UserDTO(x)).ToList();
        }

        public List<UserDTO> GetUsersByFilters(UserFilterDto filter)
        {
            if (filter != null && _dbContext.Users != null)
            {
                return _dbContext.Users.AsQueryable()
                    .FitlerByName(filter.Name)
                    .FilterByLogin(filter.Login)
                    .FilterByUserType(filter.UserType)
                    .FilterByIsActive(filter.isActive)
                    .FilterByCreationDate(filter.CreationDate)
                    .Select(x => new UserDTO(x))
                    .ToList();
            }
            return GetUsers();
        }

        public void UpdateUser(UserDTO userRequestDTO)
        {
            if (userRequestDTO != null)
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == userRequestDTO.Id);
                if (user != null)
                {
                    user.Login = userRequestDTO.Login;
                    user.IsActive = userRequestDTO.IsActive;
                    user.UserType = userRequestDTO.UserType;
                    user.Password = userRequestDTO.Password;
                    user.Name = userRequestDTO.Name;
                    UpdateUserAudit(user);
                    _dbContext.Update(user);
                    _dbContext.SaveChanges();
                }
            }
        }

        private void UpdateUserAudit(User user)
        {
            if (user.UserAuditId.HasValue)
            {
                var audit = _dbContext.UserAudit?.FirstOrDefault(x => x.Id == user.UserAuditId);
                if (audit != null)
                {
                    audit.UpdatedAt = DateTime.Now;
                    this._dbContext.SaveChanges();
                }
            }
            else
            {
                var audit = new UserAudit() { CreatedAt = DateTime.Now, LastLoginAt = DateTime.Now, UpdatedAt = DateTime.Now };
                this._dbContext.Add(audit);
                this._dbContext.SaveChanges();
                user.UserAudit = audit;
                user.UserAuditId = audit.Id;
            }
        }

        public int? Login(string login, string password)
        {
            if (this._dbContext.Users == null || this._dbContext.Users.Count() == 0)
                return null;
            var user = this._dbContext.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            return user != null ? user.Id : null;
        }
    }

    public static class UserQueryExtensions
    {
        public static IQueryable<User> FitlerByName(this IQueryable<User> query, string? name)
        {
            if (name != null && name != "")
                return query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            return query;
        }

        public static IQueryable<User> FilterByLogin(this IQueryable<User> query, string? login)
        {
            if (login != null && login != "")
                return query.Where(x => x.Login.ToLower().Contains(login.ToLower()));
            return query;
        }

        public static IQueryable<User> FilterByUserType(this IQueryable<User> query, int? userType)
        {
            if (userType.HasValue)
                return query.Where(x => x.UserType == (UserType)userType);
            return query;
        }

        public static IQueryable<User> FilterByIsActive(this IQueryable<User> query, bool? isActive)
        {
            if (isActive.HasValue)
                return query.Where(x => x.IsActive == isActive);
            return query;

        }
        public static IQueryable<User> FilterByCreationDate(this IQueryable<User> query, DateTime? creationDate)
        {
            if (creationDate.HasValue)
                return query.Where(x => x.UserAudit != null && x.UserAudit.CreatedAt >= creationDate);
            return query;
        }
    }
}
