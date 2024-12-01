using IdentityWithJwtTestProject.DataAccessLayer.Responses.UserResponses;
using IdentityWithJwtTestProject.DtoLayer.Dtos.TokenDtos;
using IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract
{
    public interface IAuthService
    {
        Task<LoginUserResponse> LoginAsync(LoginUserDto loginDto);
        Task<LoginUserResponse> RefreshTokenLoginAsync(RefreshTokenDto refreshToken);
    }
}
