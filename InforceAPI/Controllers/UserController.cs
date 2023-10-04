using InforceAPI.Models;
using InforceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace InforceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(User request)
        {
            var response = await _userService.Register(request);
            if(response == null) return BadRequest();
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(User request)
        {
            var response = await _userService.Login(request);
            if (response == null) return BadRequest();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var response = await _userService.GetUser(id);
            if(response == null) return NotFound();
            return Ok(response);
        }

    }
}
