using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUserByUserId(Guid UserId)
        {
            if (UserId == Guid.Empty)
            {
                return BadRequest("Invalid User Id");
            }

            UserDTO? response = await _usersService.GetUserByUserId(UserId);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
