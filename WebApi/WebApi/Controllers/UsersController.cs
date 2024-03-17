using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.UserEntities;
using WebApi.Models.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MeteoContext _context;

        public UsersController(MeteoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.Select(x => new UserResponseDTO(x)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetById(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user != null ? new UserResponseDTO(user) : NotFound();
        }

        [HttpPost]
        public async Task<bool> AddUser(UserRequestDTO userDto)
        {
            if (userDto != null)
            {
                var lastId = _context.Users?.Max(x => x.Id);
                var user = new User()
                {
                    Id = lastId ?? 1,
                    Name = userDto.Name,
                    Login = userDto.Login,
                    Password = userDto.Password,
                    UserType = userDto.UserType,
                    IsActive = userDto.IsActive,
                    UserAudit = new UserAudit()
                    {
                        LastLoginAt = null,
                        UpdatedAt = DateTime.Now,
                        CreatedAt = DateTime.Now,
                    }
                };
                _context.Add(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPut]
        public async Task<bool> UpdateUser(UserRequestDTO userDto)
        {
            if (_context.Users != null)
            {
                var dbUser = _context.Users?.FirstOrDefault(x => x.Id == userDto.Id);
                if (dbUser != null)
                {
                    dbUser.Name = userDto.Name;
                    dbUser.Login = userDto.Login;
                    dbUser.Password = userDto.Password;
                    dbUser.UserType = userDto.UserType;
                    dbUser.IsActive = userDto.IsActive;
                    var audit = dbUser.UserAudit;
                    if (audit != null)
                    {
                        audit.UpdatedAt = DateTime.Now;
                        _context.Update(audit);
                        _context.SaveChanges();
                    }
                    else
                    {
                        audit = new UserAudit();
                        audit.UpdatedAt = DateTime.Now;
                        audit.CreatedAt = DateTime.Now;
                        audit.LastLoginAt = null;
                        _context.Add(audit);
                        _context.SaveChanges();
                        dbUser.UserAudit = audit;
                    }
                    _context.Update(dbUser);
                    _context.SaveChanges();
                }
                return false;
            }
            return false;
        }

        [HttpPut]
        public async Task<bool> DeleteUser(int userId)
        {
            if (_context.Users != null)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
