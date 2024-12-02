using Microsoft.AspNetCore.Mvc;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DataAccessLayer.Attributes;
using IdentityWithJwtTestProject.DataAccessLayer.Datas;
using IdentityWithJwtTestProject.DataAccessLayer.Enums;

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
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Users,
            ActionType = ActionType.Reading, Definition = "Get Users")]
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
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Users,
            ActionType = ActionType.Writing, Definition = "Assign Role To User")]
        public async Task<IActionResult> AssignRoleToUserAsync(AssignRoleToUserDto assignRoleDto)
        {
            await _userService.AssignRoleToUserAsync(assignRoleDto);
            return Ok();
        }
    }
}
