using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DtoLayer.Dtos.TokenDtos;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWithJwtTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto loginUserDto)
        {
            var response = await _authService.LoginAsync(loginUserDto);
            return response.Succeeded
                ? Ok(response)
                : BadRequest(response);
        }

        [HttpPost("RefreshTokenLogin")]
        public async Task<IActionResult> RefreshTokenLoginAsync(RefreshTokenDto refreshTokenDto)
        {
            var response = await _authService.RefreshTokenLoginAsync(refreshTokenDto);
            return response.Succeeded
                ? Ok(response) 
                : BadRequest(response);
        }
    }
}
