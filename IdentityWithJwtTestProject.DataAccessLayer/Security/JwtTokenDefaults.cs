using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Security
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "TestProjectSecretKeyForIdentityWithJwt";
    }
}
