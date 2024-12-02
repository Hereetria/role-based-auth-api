using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.EntityLayer.Entities
{
    public class Endpoint
    {
        public string EndpointId { get; set; }
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }

        public Menu Menu { get; set; }
        public ICollection<AppRoleEndpoint> AppRoleEndpoints { get; set; } = new List<AppRoleEndpoint>();

        public Endpoint()
        {
            EndpointId = Guid.NewGuid().ToString();
        }
    }
}
