using AutoMapper;
using IdentityWithJwtTestProject.DataAccessLayer.Contexts;
using IdentityWithJwtTestProject.DataAccessLayer.Services.Abstract;
using IdentityWithJwtTestProject.DtoLayer.Dtos.ProductDtos;
using IdentityWithJwtTestProject.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ProductService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultProductDto>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<ResultProductByIdDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with id {id} not found.");

            return _mapper.Map<ResultProductByIdDto>(product);
        }

        public async Task CreateProductAsync(CreateProductDto createDto)
        {
            var product = _mapper.Map<Product>(createDto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(UpdateProductDto updateDto)
        {
            var product = await _context.Products.FindAsync(updateDto.ProductId);
            if (product == null)
                throw new KeyNotFoundException($"Product with id {updateDto.ProductId} not found.");

            _mapper.Map(updateDto, product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with id {id} not found.");

            _context.Products.Remove(product);
        }
    }
}
