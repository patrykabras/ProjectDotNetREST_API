using System.Collections.Generic;
using System.Threading.Tasks;
using CryptaEcillas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptaEcillas.Controllers
{
    [ApiController]
    [Route("api/Test")]
    public class UserTController : ControllerBase
    {
        private readonly ILogger<UserTController> _logger;
        private readonly UserDbContext _context;

        public UserTController(ILogger<UserTController> logger, UserDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = _context.getUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult getUserById(int id)
        {
            User user = _context.getUserById(id);
            return Ok(user);
        }
        [HttpPost]
        [Route("user")]
        public IActionResult AddUser(User user)
        {
            _logger.LogInformation("Add User for UserId: {UserId}", user.Id);
            _context.addUser(user);
            return Ok(user);
        }
    }
}