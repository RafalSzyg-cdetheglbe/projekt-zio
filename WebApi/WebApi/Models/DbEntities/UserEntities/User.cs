﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DbEntities.UserEntities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Login { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public UserAudit UserAudit { get; set; }
    }
}
