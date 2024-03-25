using WebApi.Models.DbEntities.UserEntities;

namespace WebApi.Models.DTO
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public UserResponseDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            UserType = user.UserType;
            IsActive = user.IsActive;
        }
    }
    public class UserRequestDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public UserRequestDTO(int id, string login, string password, string name, UserType userType, bool isActive)
        {
            Id = id;
            Name = name;
            UserType = userType;
            IsActive = isActive;
            Login = login;
            Password = password;
        }
    }
}
