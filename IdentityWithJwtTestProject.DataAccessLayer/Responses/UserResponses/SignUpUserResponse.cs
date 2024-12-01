using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Responses.UserResponses
{
    public abstract class SignUpUserResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        protected SignUpUserResponse(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }

    public class SignUpUserSuccessResponse : SignUpUserResponse
    {
        public SignUpUserSuccessResponse(string message)
            : base (true, message)
        {
        }
    }

    public class SignUpUserFailureResponse : SignUpUserResponse
    {
        public List<string> Errors { get; set; } = new List<string>();

        public SignUpUserFailureResponse(string message, List<string> errors)
            : base(false, message)
        {
            Errors = errors ?? new List<string>();
        }

        public SignUpUserFailureResponse(string message)
            : base(false, message)
        {
            Errors = new List<string>();
        }
    }
}
