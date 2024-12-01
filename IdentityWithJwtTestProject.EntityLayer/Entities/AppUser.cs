using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.EntityLayer.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
