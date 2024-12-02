using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos
{
    public class ResultRolesToUserDto
    {
        public List<string> Roles { get; set; } = new List<string>();
    }
}
