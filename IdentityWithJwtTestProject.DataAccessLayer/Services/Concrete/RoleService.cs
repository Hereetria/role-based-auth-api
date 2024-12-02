using AutoMapper;
using IdentityWithJwtTestProject.DataAccessLayer.Contexts;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DtoLayer.Dtos.RoleDtos;
using IdentityWithJwtTestProject.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<ResultRolesDto>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var result = _mapper.Map<List<ResultRolesDto>>(roles);

            return result != null
                ? result
                : new List<ResultRolesDto>();
        }

        public async Task<ResultRoleByIdDto> GetRoleByIdAsync(string id)
        {
            var role = await _roleManager.RoleExistsAsync(id);
            var result = _mapper.Map<ResultRoleByIdDto>(role);

            return result;
        }

        public async Task<bool> CreateRoleAsync(CreateRoleDto createDto)
        {
            var role = _mapper.Map<AppRole>(createDto);
            IdentityResult result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> UpdateRoleAsync(UpdateRoleDto updateDto)
        {
            var role = _mapper.Map<AppRole>(updateDto);
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(string id)
        {
            IdentityResult result = await _roleManager.DeleteAsync(
                new AppRole { Id = id });
            return result.Succeeded;
        }
    }
}
