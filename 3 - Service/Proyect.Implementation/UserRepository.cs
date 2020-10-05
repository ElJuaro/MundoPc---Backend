using Project.Domain.Entities;
using Project.Infraestructure;
using Project.Infraestructure.Repository;
using Proyect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _userRepository;
        DataContext _context;

        public UserRepository(IRepository<User> userRepository, DataContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task Create(User dto)
        {
            var newUser = new User()
            {
                UserName = dto.UserName,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Role = dto.Role,
                Telephone = dto.Telephone,

                
            };
            await _userRepository.Create(newUser);
        }

        public async Task Delete(User entity)
        {
            await _userRepository.Delete(entity);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var userAll =
                await _userRepository.GetAll(null, null, false);

            return userAll.Select(x => new User()
            {
                Id = x.Id,
                UserName = x.UserName,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Role = x.Role,
                Telephone = x.Telephone,

            });
        }

        public async Task<User> GetById(long UserId)
        {
            return await _userRepository.GetById(UserId);
        }

        public async Task<bool> GetLoginByCredentials(string username, string password)
        {
            var usuario = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            bool resultado = await Task.Run(() =>
             {
                 if (usuario == null)
                 {
                     return false;
                 }

                 return true;
             });
            return resultado;
                

        }


        public async Task Update(User dto)
        {
            await _userRepository.Update(dto);
        }
    }
}
