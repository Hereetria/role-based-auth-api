using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DtoLayer.Dtos.TokenDtos
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpireDate { get; set; }

        public Token(string accessToken, string refreshToken, DateTime expireDate)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpireDate = expireDate;
        }
    }
}
