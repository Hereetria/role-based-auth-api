using IdentityWithJwtTestProject.DataAccessLayer.Responses.UserResponses;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using IdentityWithJwtTestProject.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract
{
    public interface IUserService
    {
        Task<SignUpUserResponse> SignUpAsync(SignUpUserDto createDto);
        Task UpdateRefreshToken(string refreshToken, AppUser user,
            DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
