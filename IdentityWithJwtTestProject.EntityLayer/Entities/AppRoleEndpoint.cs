using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.EntityLayer.Entities
{
    public class AppRoleEndpoint
    {
        public string AppRoleEndpointId { get; set; }

        public string AppRoleId { get; set; }
        public AppRole AppRole { get; set; }

        public string EndpointId { get; set; }
        public Endpoint Endpoint { get; set; }

        public AppRoleEndpoint()
        {
            AppRoleEndpointId = Guid.NewGuid().ToString();
        }
    }
}
