using Project.Domain.Entities;
using Project.Infraestructure;
using Project.Infraestructure.Repository;
using Proyect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyect.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Product> _productRepository;
        DataContext _context;

        public ProductRepository(IRepository<Product> productRepository, DataContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public async Task Create(Product dto)
        {
            var newProduct = new Product()
            {
               Codigo = dto.Codigo,
               Description = dto.Description,
               SalePrice = dto.SalePrice,
               Stock = dto.Stock,
            };
            await _productRepository.Create(newProduct);
        }

        public async Task Delete(Product entity)
        {
            await _productRepository.Delete(entity);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var productAll =
                await _productRepository.GetAll(null, null, false);

            return productAll.Select(x => new Product()
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Description = x.Description,
                IsDeleted = x.IsDeleted,
                SalePrice = x.SalePrice,
                Stock = x.Stock
            }); 
        }

        public async Task<Product> GetById(long Id)
        {
            return await _productRepository.GetById(Id);
        }

        public async Task Update(Product dto)
        {
            await _productRepository.Update(dto);
        }
    }
}
