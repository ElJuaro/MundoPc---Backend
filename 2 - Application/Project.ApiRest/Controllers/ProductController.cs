using Microsoft.AspNetCore.Mvc;
using Project.Domain.Entities;
using Proyect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _productRepository.GetAll();
            return Ok(product.Where(x => !x.IsDeleted));
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return Ok("Product NotExist");
            }

        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var newProduct = new Product()
            {
               Codigo = product.Codigo,
               Description = product.Description,
               SalePrice = product.SalePrice,
               Stock = product.Stock
            };
            await _productRepository.Create(newProduct);
            return Ok(newProduct);

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Product product)
        {
            var _product = await _productRepository.GetById(product.Id);

            if (_product != null)
            {
                _product.Codigo = product.Codigo;
                _product.Description = product.Description;
                _product.SalePrice = product.SalePrice;
                _product.Stock = product.Stock;

                await _productRepository.Update(_product);
                return Ok(_product);
            }
            else
            {
                return Ok("Product NotExist");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var _productDelete = await _productRepository.GetById(id);
            if (_productDelete != null)
            {
                await _productRepository.Delete(_productDelete);
                return Ok(_productDelete);
            }
            else
            {
                return Ok("Product NotExist");
            }
        }

    }
}
