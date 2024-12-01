using AutoMapper;
using IdentityWithJwtTestProject.DataAccessLayer.Responses.UserResponses;
using IdentityWithJwtTestProject.DataAccessLayer.Security;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DataAccessLayer.Validations.ValidationServices;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using IdentityWithJwtTestProject.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IValidatorService _validatorService;

        public UserService(IMapper mapper, UserManager<AppUser> userManager, IValidatorService validatorService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _validatorService = validatorService;
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
    }
}
