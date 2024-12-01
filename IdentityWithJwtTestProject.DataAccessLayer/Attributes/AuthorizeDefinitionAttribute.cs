using IdentityWithJwtTestProject.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Attributes
{
    public class AuthorizeDefinitionAttribute : Attribute
    {
        public string MenuName {  get; set; }
        public ActionType ActionType { get; set; }
        public string Definition { get; set; }
    }
}
