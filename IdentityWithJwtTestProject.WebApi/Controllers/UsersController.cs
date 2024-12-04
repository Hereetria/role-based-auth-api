using Microsoft.AspNetCore.Mvc;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DataAccessLayer.Attributes;
using IdentityWithJwtTestProject.WebApi.Controllers;

namespace userWithJwtTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [AuthorizeDefinition(ControllerName = nameof(UsersController), MethodName = nameof(GetUsers))]
        public async Task<IActionResult> GetUsers()
        {
            var values = await _userService.GetUsersAsync();
            return Ok(values);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> SignUpAsync(SignUpUserDto createDto)
        {
            var response = await _userService.SignUpAsync(createDto);
            return response.Succeeded
                ? Ok(response)
                : BadRequest(response);
        }

        [HttpPost("AssignRoleToUser")]
        [AuthorizeDefinition(ControllerName = nameof(UsersController), MethodName = nameof(AssignRoleToUserAsync))]
        public async Task<IActionResult> AssignRoleToUserAsync(AssignRoleToUserDto assignRoleDto)
        {
            await _userService.AssignRoleToUserAsync(assignRoleDto);
            return Ok();
        }

        [HttpPost("HasRolepermissionToEndpoint")]
        public async Task<IActionResult> HasRolePermissionToEndpoint(HasRolePermissionToEndpointDto hasRolePermissionDto)
        {
            var result = await _userService.HasRolePermissionToEndpointAsync(hasRolePermissionDto);
            return result == true
                ? Ok()
                : BadRequest();
        }
    }
}
