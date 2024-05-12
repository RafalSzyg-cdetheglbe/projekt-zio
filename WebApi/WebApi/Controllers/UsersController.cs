using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.UserEntities;
using WebApi.Models.DTO;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UsersController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return _userInterface.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            return _userInterface.GetUser(id);
        }

        [HttpPost]
        public async Task<int> AddUser(UserDTO userDto)
        {
            return _userInterface.AddUser(userDto);
        }

        [HttpPut]
        public async Task UpdateUser(UserDTO userDto)
        {
            if (userDto != null)
                _userInterface.UpdateUser(userDto);
        }

        [HttpDelete]
        public async Task<bool> DeleteUser(int userId)
        {
            return _userInterface.DeleteUser(userId);
        }

        [HttpGet("login")]
        public async Task<int?> Login(string login, string password)
        {
            return _userInterface.Login(login, password);
        }
    }
}
