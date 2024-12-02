using IdentityWithJwtTestProject.DataAccessLayer.Attributes;
using IdentityWithJwtTestProject.DataAccessLayer.Datas;
using IdentityWithJwtTestProject.DataAccessLayer.Enums;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DtoLayer.Dtos.RoleDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWithJwtTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Roles,
            ActionType = ActionType.Reading, Definition = "Get Role")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRolesAsync();
            return roles != null 
                ? Ok(roles) 
                : NotFound("Roles not found");
        }

        [HttpGet("{id}")]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Roles,
            ActionType = ActionType.ReadingById, Definition = "Get Role By Id")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            return role != null 
                ? Ok(role) 
                : NotFound($"Role with ID {id} not found");
        }

        [HttpPost]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Roles,
            ActionType = ActionType.Writing, Definition = "Create Role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createDto)
        {
            var result = await _roleService.CreateRoleAsync(createDto);
            return result 
                ? Ok("Role created successfully") 
                : BadRequest("Failed to create role");
        }

        [HttpPut]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Roles,
            ActionType = ActionType.Updating, Definition = "Update Role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateDto)
        {
            var result = await _roleService.UpdateRoleAsync(updateDto);
            return result 
                ? Ok("Role updated successfully") 
                : BadRequest("Failed to update role");
        }

        [HttpDelete("{id}")]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Roles,
            ActionType = ActionType.Deleting, Definition = "Delete Role")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            return result 
                ? Ok("Role deleted successfully") 
                : BadRequest("Failed to delete role");
        }
    }

}
