using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Attributes
{
    public class AuthorizeDefinitionAttribute : Attribute
    {
        public string ControllerName {  get; set; }
        public string MethodName { get; set; }
}
}
