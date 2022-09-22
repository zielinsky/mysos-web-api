using Microsoft.AspNetCore.Mvc;
using mysos_web_api.Entities;
using mysos_web_api.Repositories;

namespace mysos_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if(await _userRepository.Add(user))
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
