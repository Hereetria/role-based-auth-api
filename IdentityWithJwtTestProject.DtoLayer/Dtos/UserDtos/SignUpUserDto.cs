using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos
{
    public class SignUpUserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
    }
}
