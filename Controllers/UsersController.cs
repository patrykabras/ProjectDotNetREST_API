using System.Collections.Generic;
using System.Threading.Tasks;
using CryptaEcillas.Data;
using CryptaEcillas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptaEcillas.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UsersController(IUserRepo repository)
        {
            _repository = repository;
        }
        //Get api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var userItems = _repository.GetUsers();

            return Ok(userItems);
        }

        //Get api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            return Ok(userItem);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User userItem)
        {
            //AddUser
            return Ok(userItem);
        }
    }
}