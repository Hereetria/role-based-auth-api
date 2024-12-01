using IdentityWithJwtTestProject.DtoLayer.Dtos.TokenDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Responses.UserResponses
{
    public abstract class LoginUserResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        protected LoginUserResponse(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }

    public class LoginUserSuccessResponse : LoginUserResponse
    {
        public Token TokenResponse { get; set; }

        public LoginUserSuccessResponse(string message, Token tokenResponse)
            : base(true, message)
        {
            TokenResponse = tokenResponse;
        }
    }

    public class LoginUserFailureResponse : LoginUserResponse
    {
        public List<string> Errors { get; set; } = new List<string>();

        public LoginUserFailureResponse(string message, List<string> errors)
            : base(false, message)
        {
            Errors = errors ?? new List<string>();
        }

        public LoginUserFailureResponse(string message)
            : base(false, message)
        {
            Errors = new List<string>();
        }
    }
}
