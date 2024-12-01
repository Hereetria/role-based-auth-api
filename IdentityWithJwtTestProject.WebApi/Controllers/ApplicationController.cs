using IdentityWithJwtTestProject.DataAccessLayer.Attributes;
using IdentityWithJwtTestProject.DataAccessLayer.Datas;
using IdentityWithJwtTestProject.DataAccessLayer.Enums;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWithJwtTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Application, ActionType = ActionType.Reading,
            Definition = "Get Authorize Definition Endpoints")]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var datas = _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}
