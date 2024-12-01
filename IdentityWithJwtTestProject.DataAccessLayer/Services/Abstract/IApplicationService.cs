using IdentityWithJwtTestProject.DataAccessLayer.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract
{
    public interface IApplicationService
    {
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
