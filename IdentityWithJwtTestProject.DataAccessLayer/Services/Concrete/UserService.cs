using AutoMapper;
using IdentityWithJwtTestProject.DataAccessLayer.Contexts;
using IdentityWithJwtTestProject.DataAccessLayer.Responses.UserResponses;
using IdentityWithJwtTestProject.DataAccessLayer.Security;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DataAccessLayer.Validations.ValidationServices;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using IdentityWithJwtTestProject.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IValidatorService _validatorService;

        public UserService(Context context, IMapper mapper, UserManager<AppUser> userManager, IValidatorService validatorService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _validatorService = validatorService;
        }

        public async Task<List<ResultUsersDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = _mapper.Map<List<ResultUsersDto>>(users);

            return result;
        }

        public async Task<SignUpUserResponse> SignUpAsync(SignUpUserDto createDto)
        {
            var validationResult = await _validatorService.ValidateAsync(createDto);
            if (!validationResult.IsValid)
            {
                string message = "User data is not valid";
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return new SignUpUserFailureResponse(message, errors);
            }

            var user = _mapper.Map<AppUser>(createDto);
            IdentityResult result = await _userManager.CreateAsync(user, createDto.Password);

            return result.Succeeded
                ? new SignUpUserSuccessResponse("User has created successfully")
                : new SignUpUserFailureResponse("An error occurred while creating the user.", result.Errors.Select(e => e.Description).ToList());
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user,
            DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user == null)
                throw new Exception("User Not Found");

            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
            await _userManager.UpdateAsync(user);
        }

        public async Task AssignRoleToUserAsync(AssignRoleToUserDto assignRoleDto)
        {
            AppUser? user = await _userManager.FindByIdAsync(assignRoleDto.UserId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                await _userManager.AddToRolesAsync(user, assignRoleDto.Roles);
            }
        }

        public async Task<List<string>> GetRolesToUserAsync(string userIdOrName)
        {
            AppUser? user = await _userManager.FindByIdAsync(userIdOrName);
            if (user == null) 
                user = await _userManager.FindByNameAsync(userIdOrName);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToList();
            }
            return new List<string>();
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(HasRolePermissionToEndpointDto hasRolePermissionDto)
        {
            var userRoles = await GetRolesToUserAsync(hasRolePermissionDto.Name);
            if (!userRoles.Any())
                return false;

            Endpoint? endpoint = await _context.Endpoints
                .Include(e => e.AppRoleEndpoints)
                    .ThenInclude(e => e.AppRole)
                .FirstOrDefaultAsync(e => e.Code == hasRolePermissionDto.Code);

            if (endpoint == null)
                return false;

            var hasRole = false;
            var endpointRoles = endpoint.AppRoleEndpoints.Select(r => r.AppRole.Name);

            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                {
                    if (userRole == endpointRole)
                        return true;
                }
            }
            return false;
        }
    }
}
