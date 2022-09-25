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
            _logger.LogInformation("Adding user...");

            if (await _userRepository.Add(user))
            {
                _logger.LogInformation("User successfully added");
                return Ok();
            }

            _logger.LogError("Adding user failed");
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            _logger.LogInformation("Getting user...");

            User? user = await _userRepository.Find(id);
            
            if(user == null)
            {
                _logger.LogWarning($"User with id = {id} not found.");
                return NotFound();
            }

            _logger.LogInformation("User successfully found");
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetUsers()
        {
            _logger.LogInformation("Getting users...");
            List<User> users;
            try
            {
                _logger.LogError("Users sucessfully got");
                users = _userRepository.GetAll();
                return Ok(users);
            }
            catch
            {
                _logger.LogError("Error in /api/User/GetUsers");
                users = new List<User> { };
                return BadRequest(users);
            }

        }

    }
}
