using IdentityWithJwtTestProject.DtoLayer.Dtos.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract
{
    public interface IRoleService
    {
        Task<List<ResultRolesDto>> GetRolesAsync();
        Task<ResultRoleByIdDto> GetRoleByIdAsync(string id);
        Task<bool> CreateRoleAsync(CreateRoleDto createDto);
        Task<bool> UpdateRoleAsync(UpdateRoleDto updateDto);
        Task<bool> DeleteRoleAsync(string id);
    }
}
