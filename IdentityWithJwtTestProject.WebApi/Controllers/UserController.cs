using Microsoft.AspNetCore.Mvc;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;

namespace userWithJwtTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService  userService)
        {
            _userService =  userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> SignUpAsync(SignUpUserDto createDto) 
        {
            var response = await _userService.SignUpAsync(createDto);
            return response.Succeeded 
                ? Ok(response) 
                : BadRequest(response);
        }
    }
}
