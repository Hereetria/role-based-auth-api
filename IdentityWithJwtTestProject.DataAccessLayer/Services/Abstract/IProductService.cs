using IdentityWithJwtTestProject.DtoLayer.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetProductsAsync();
        Task<ResultProductByIdDto> GetProductByIdAsync(int id);
        Task CreateProductAsync(CreateProductDto createDto);
        Task UpdateProductAsync(UpdateProductDto updateDto);
        Task DeleteProductAsync(int id);
    }
}
