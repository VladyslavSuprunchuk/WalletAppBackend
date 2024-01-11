using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WalletAppBackend.Core.Models;
using WalletAppBackend.DatabaseProvider.Models;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            var user = await _userService.GetUserAsync(id);

            var userClient = _mapper.Map<UserClient>(user);

            return Ok(userClient);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserClient userClient)
        {
            var user = _mapper.Map<User>(userClient);
            user = await _userService.CreateUserAsync(user);
            userClient = _mapper.Map<UserClient>(user);

            return Ok(userClient);
        }
    }
}
