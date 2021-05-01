using System.Collections.Generic;
using BookReservationAPI.Models;
using BookReservationAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserReservationAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserModelsController : ControllerBase
    {
        private readonly IUserRepository<UserModel> _dataRepository;
        public UserModelsController(IUserRepository<UserModel> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/UserModel
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserModel> Users = _dataRepository.GetAll();
            return Ok(Users);
        }
        // GET: api/UserModel/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserModel User = _dataRepository.Get(id);
            if (User == null)
            {
                return NotFound("The UserModel record couldn't be found.");
            }
            return Ok(User);
        }
        // POST: api/UserModel
        [HttpPost]
        public IActionResult Post([FromBody] UserModel User)
        {
            if (User == null)
            {
                return BadRequest("UserModel is null.");
            }
            _dataRepository.Add(User);
            return CreatedAtRoute(
                  "Get",
                  new { Id = User.Id },
                  User);
        }
        [Route("/auth")]
        [HttpPost]
        public IActionResult Post2([FromBody] UserModel User)
        {
            if (User == null)
            {
                return BadRequest("UserModel is null.");
            }
            var r = _dataRepository.GetAll();

            foreach (var item in r)
            {
                if (User.Username == item.Username && User.Password == item.Password) return Ok(item);
            }
            return BadRequest("UserModel is null.");
        }
        // PUT: api/UserModel/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModel User)
        {
            if (User == null)
            {
                return BadRequest("UserModel is null.");
            }
            UserModel UserToUpdate = _dataRepository.Get(id);
            if (UserToUpdate == null)
            {
                return NotFound("The UserModel record couldn't be found.");
            }
            _dataRepository.Update(UserToUpdate, User);
            return NoContent();
        }
        // DELETE: api/UserModel/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserModel User = _dataRepository.Get(id);
            if (User == null)
            {
                return NotFound("The UserModel record couldn't be found.");
            }
            _dataRepository.Delete(User);
            return NoContent();
        }
    }
}