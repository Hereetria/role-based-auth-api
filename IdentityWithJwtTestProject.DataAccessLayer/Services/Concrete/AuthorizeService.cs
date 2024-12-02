using IdentityWithJwtTestProject.DataAccessLayer.Contexts;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DtoLayer.Dtos.AuthorizationDtos;
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
    public class AuthorizeService : IAuthorizeService
    {
        private readonly Context _context;
        private readonly IApplicationService _applicationService;
        private readonly RoleManager<AppRole> _roleManager;

        public AuthorizeService(Context context, IApplicationService applicationService, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _applicationService = applicationService;
            _roleManager = roleManager;
        }

        public async Task AssignRoleEndpointAsync(AssignRoleEndpointDto endpointDto)
        {
            var entityEntry = await _context.Menus.AddAsync(new Menu() { Name = endpointDto.Menu });
            Menu _menu = entityEntry.Entity;
            if (_menu != null)
            {
                _menu = new Menu() { Name = endpointDto.Menu };

                await _context.Menus.AddAsync(_menu);
                await _context.SaveChangesAsync();
            }

            Endpoint? endpoint = await _context.Endpoints
                .Include(e => e.Menu)
                .Include(e => e.AppRoleEndpoints)
                    .ThenInclude(e => e.AppRole)
                .FirstOrDefaultAsync();

            if (endpoint == null)
            {
                var action = endpointDto.ActionMenus
                    .FirstOrDefault(m => m.Name == endpointDto.Menu)
                    ?.Actions.FirstOrDefault(e => e.Code == endpointDto.Code);

                endpoint = new()
                {
                    Code = action.Code,
                    ActionType = action.ActionType,
                    HttpType = action.HttpType,
                    Definition = action.Definition,
                    Menu = _menu
                };

                await _context.Endpoints.AddAsync(endpoint);
                await _context.SaveChangesAsync();
            }

            foreach (var role in endpoint.AppRoleEndpoints.Select(x => x.AppRole))
                endpoint.AppRoleEndpoints.Select(x => x.AppRole.Id == role.Id);

            var appRoles = await _roleManager.Roles
                .Where(r => endpointDto.Roles.Contains(r.Name))
                .ToListAsync();

            appRoles.ForEach(role =>
                endpoint.AppRoleEndpoints.Add(new AppRoleEndpoint
                {
                    AppRole = role,
                    Endpoint = endpoint
                })
            );


            await _context.SaveChangesAsync();
        }
    }
}
