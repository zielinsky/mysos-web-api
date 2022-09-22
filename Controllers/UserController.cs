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
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if(await _userRepository.Add(user))
            {
                _logger.LogInformation($"User successfully added");
                return Ok();
            }

            _logger.LogError("Adding user failed");
            return BadRequest();
        }

    }
}
