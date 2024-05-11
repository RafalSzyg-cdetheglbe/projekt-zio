using System.ComponentModel.DataAnnotations;
using WebApi.Models.DTO;

namespace WebApi.Models.DbEntities.UserEntities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
        [Required]
        [StringLength(255)]
        public string? Login { get; set; }
        [Required]
        [StringLength(255)]
        public string? Password { get; set; }
        [Required]
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public UserAudit? UserAudit { get; set; }
        public User() { }
        public User(UserDTO userRequestDTO)
        {
            Id = userRequestDTO.Id;
            Name = userRequestDTO.Name;
            Login = userRequestDTO.Login;
            Password = userRequestDTO.Password;
            UserType = userRequestDTO.UserType;
            IsActive = userRequestDTO.IsActive;
            UserType = userRequestDTO.UserType;
        }
    }
}
