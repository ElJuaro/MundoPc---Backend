using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Interface
{
    public interface IUserRepository
    {
        Task Create(User dto);
        Task Update(User dto);
        Task Delete(User dto);
        Task<User> GetById(long UserId);
        Task<IEnumerable<User>> GetAll();

        Task<bool> GetLoginByCredentials(string username, string password);

    }
}
