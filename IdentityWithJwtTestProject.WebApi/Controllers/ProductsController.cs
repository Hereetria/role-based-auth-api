using IdentityWithJwtTestProject.DataAccessLayer.Attributes;
using IdentityWithJwtTestProject.DataAccessLayer.Datas;
using IdentityWithJwtTestProject.DataAccessLayer.Enums;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DtoLayer.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWithJwtTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Products,
            ActionType = ActionType.Reading, Definition = "Get Product")]
        public async Task<ActionResult<List<ResultProductDto>>> GetProducts()
        {
            var values = await _productService.GetProductsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Products,
            ActionType = ActionType.ReadingById, Definition = "Get Product By Id")]
        public async Task<ActionResult<ResultProductByIdDto>> GetProductById(int id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Products,
            ActionType = ActionType.Writing, Definition = "Create Product")]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductDto createDto)
        {
            await _productService.CreateProductAsync(createDto);
            return Ok();
        }

        [HttpPut]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Products,
            ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductDto updateDto)
        {
            await _productService.UpdateProductAsync(updateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [AuthorizeDefinition(MenuName = AuthorizeDefinitionMenus.Products,
            ActionType = ActionType.Deleting, Definition = "Delete Product")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
