using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyect.Interface
{
    public interface IProductRepository
    {
        Task Create(Product dto);
        Task Update(Product dto);
        Task Delete(Product dto);
        Task<Product> GetById(long UserId);
        Task<IEnumerable<Product>> GetAll();
    }
}
