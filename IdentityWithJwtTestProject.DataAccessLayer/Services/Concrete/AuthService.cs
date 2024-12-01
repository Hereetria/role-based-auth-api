using AutoMapper;
using IdentityWithJwtTestProject.DataAccessLayer.Responses.UserResponses;
using IdentityWithJwtTestProject.DataAccessLayer.Security;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DataAccessLayer.Validations.ValidationServices;
using IdentityWithJwtTestProject.DtoLayer.Dtos.TokenDtos;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
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
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IValidatorService _validatorService;

        public AuthService(UserManager<AppUser> userManager, IUserService userService, IValidatorService validatorService)
        {
            _userManager = userManager;
            _userService = userService;
            _validatorService = validatorService;
        }
        public async Task<LoginUserResponse> LoginAsync(LoginUserDto loginDto)
        {
            var validationResult = await _validatorService.ValidateAsync(loginDto);
            if (!validationResult.IsValid)
            {
                string message = "User data is not valid";
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return new LoginUserFailureResponse(message, errors);
            }

            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
                return new LoginUserFailureResponse("User not found.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
                return new LoginUserFailureResponse("Invalid credentials");


            var token = JwtTokenGenerator.GenerateToken(15);
            await _userService.UpdateRefreshToken(token.RefreshToken, user, token.ExpireDate, 5);
            
            return new LoginUserSuccessResponse(
                "User logged in successfully",
                token
            );
        }

        public async Task<LoginUserResponse> RefreshTokenLoginAsync(RefreshTokenDto refreshTokenDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshTokenDto.RefreshToken);
            if (user == null)
                return new LoginUserFailureResponse("User cannot be null");

            Token token = JwtTokenGenerator.GenerateToken(45);
            await _userService.UpdateRefreshToken(token.RefreshToken, user, token.ExpireDate, 15);

            return new LoginUserSuccessResponse(
                "User logged in successfully",
                token
            );
        }
    }
}
