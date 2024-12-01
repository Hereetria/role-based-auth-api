using IdentityWithJwtTestProject.DtoLayer.Dtos.TokenDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Responses.UserResponses
{
    public abstract class RefreshTokenLoginResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        protected RefreshTokenLoginResponse(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }

    public class RefreshTokenLoginSuccessResponse : RefreshTokenLoginResponse
    {
        public Token TokenResponse { get; set; }

        public RefreshTokenLoginSuccessResponse(string message, Token tokenResponse)
            : base(true, message)
        {
            TokenResponse = tokenResponse;
        }
    }

    public class RefreshTokenLoginFailureResponse : RefreshTokenLoginResponse
    {
        public List<string> Errors { get; set; } = new List<string>();

        public RefreshTokenLoginFailureResponse(string message, List<string> errors)
            : base(false, message)
        {
            Errors = errors ?? new List<string>();
        }

        public RefreshTokenLoginFailureResponse(string message)
            : base(false, message)
        {
            Errors = new List<string>();
        }
    }
}
