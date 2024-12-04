using IdentityWithJwtTestProject.DataAccessLayer.Attributes;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DtoLayer.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using userWithJwtTestProject.WebApi.Controllers;

namespace IdentityWithJwtTestProject.WebApi.Controllers
{
    [Authorize]
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
        [AuthorizeDefinition(ControllerName = nameof(ProductsController), MethodName = nameof(GetProducts))]
        public async Task<ActionResult<List<ResultProductDto>>> GetProducts()
        {
            var values = await _productService.GetProductsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        [AuthorizeDefinition(ControllerName = nameof(ProductsController), MethodName = nameof(GetProductById))]
        public async Task<ActionResult<ResultProductByIdDto>> GetProductById(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        [AuthorizeDefinition(ControllerName = nameof(ProductsController), MethodName = nameof(CreateProduct))]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductDto createDto)
        {
            await _productService.CreateProductAsync(createDto);
            return Ok();
        }

        [HttpPut]
        [AuthorizeDefinition(ControllerName = nameof(ProductsController), MethodName = nameof(UpdateProduct))]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductDto updateDto)
        {
            await _productService.UpdateProductAsync(updateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [AuthorizeDefinition(ControllerName = nameof(ProductsController), MethodName = nameof(DeleteProduct))]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
