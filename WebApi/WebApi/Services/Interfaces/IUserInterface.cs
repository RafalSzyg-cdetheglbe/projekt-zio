using WebApi.Models.DTO;

namespace WebApi.Services.Interfaces
{
    public interface IUserInterface
    {
        public int AddUser(UserDTO userRequestDTO);
        public void UpdateUser(UserDTO userRequestDTO);
        public List<UserDTO> GetUsers();
        public List<UserDTO> GetUsersByFilters(UserFilterDto filter);
        public UserDTO GetUser(int userId);
        public bool DeleteUser(int userId);
        public int? Login(string login, string password);
    }

    public class UserFilterDto
    {
        public string? Name { get; set; }
        public string? Login { get; set; }
        public int? UserType { get; set; }
        public bool? isActive { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
