using WebApi.Models.DTO;

namespace WebApi.Services.Interfaces
{
    public interface IUserInterface
    {
        public int AddUser(UserRequestDTO userRequestDTO);
        public void UpdateUser(UserRequestDTO userRequestDTO);
        public List<UserResponseDTO> GetUsers();
        public List<UserResponseDTO> GetUsersByFilters(UserFilterDto filter);
        public UserResponseDTO GetUser(int userId);
        public bool DeleteUser(int userId);
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
