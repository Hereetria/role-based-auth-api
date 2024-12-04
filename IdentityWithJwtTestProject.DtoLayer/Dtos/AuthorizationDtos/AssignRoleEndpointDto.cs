using IdentityWithJwtTestProject.DataAccessLayer.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DtoLayer.Dtos.AuthorizationDtos
{
    public class AssignRoleEndpointDto
    {
        public ICollection<string> RoleIds { get; set; } = new List<string>();
        public string Menu { get; set; }
        public string Code { get; set; }

        public List<ActionMenu> ActionMenus { get; set;}
    }
}
