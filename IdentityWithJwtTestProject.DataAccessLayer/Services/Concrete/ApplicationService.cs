using IdentityWithJwtTestProject.DataAccessLayer.Attributes;
using IdentityWithJwtTestProject.DataAccessLayer.Datas;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Concrete
{
    public class ApplicationService : IApplicationService
    {
        public List<ActionMenu> GetAuthorizeDefinitionEndpoints(Type type)
        {
            var assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));

            var menus = new List<ActionMenu>();

            if (controllers == null || !controllers.Any())
                throw new NullReferenceException("Controllers cannot be null or empty");

            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute)));

                if (!actions.Any())
                    continue;

                foreach (var action in actions)
                {
                    var authorizeDefinitionAttribute = action.GetCustomAttributes(true)
                        .OfType<AuthorizeDefinitionAttribute>()
                        .FirstOrDefault();

                    if (authorizeDefinitionAttribute == null)
                        continue;

                    var className = authorizeDefinitionAttribute.ControllerName.Replace("Controller", "");

                    var menu = menus.FirstOrDefault(m => m.ClassName == className);
                    if (menu == null)
                    {
                        menu = new ActionMenu
                        {
                            ClassName = className,
                            Actions = new List<Datas.Action>()
                        };
                        menus.Add(menu);
                    }


                    if (!menus.Contains(menu))
                        menus.Add(menu);

                    var httpAttribute = action.GetCustomAttributes(true)
                        .OfType<HttpMethodAttribute>()
                        .FirstOrDefault();

                    var httpType = httpAttribute?.HttpMethods.FirstOrDefault() ?? HttpMethods.Get;

                    var _action = new Datas.Action
                    {
                        HttpType = httpType,
                        MethodName = authorizeDefinitionAttribute.MethodName,
                        Code = $"{className}.{httpType}.{authorizeDefinitionAttribute.MethodName}"
                    };

                    menu.Actions.Add(_action);
                }
            }

            return menus;
        }
    }
}
