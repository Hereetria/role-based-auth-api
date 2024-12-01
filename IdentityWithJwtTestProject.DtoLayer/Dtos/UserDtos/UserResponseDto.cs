using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DtoLayer.Dtos.UserDtos
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
