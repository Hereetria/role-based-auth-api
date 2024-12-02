using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.EntityLayer.Entities
{
    public class Menu
    {
        public string MenuId {  get; set; }
        public string Name { get; set; }
        public ICollection<Endpoint> Endpoints { get; set; } = new List<Endpoint>();

        public Menu()
        {
            MenuId = Guid.NewGuid().ToString();
        }
    }
}
