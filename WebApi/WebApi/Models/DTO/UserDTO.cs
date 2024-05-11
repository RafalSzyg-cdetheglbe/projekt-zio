using WebApi.Models.DbEntities.UserEntities;

namespace WebApi.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public UserDTO() { }
        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            UserType = user.UserType;
            IsActive = user.IsActive;
            Password = user.Password;
            Login = user.Login;
        }
    }
}
