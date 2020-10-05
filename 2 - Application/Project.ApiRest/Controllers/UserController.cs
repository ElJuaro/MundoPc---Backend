using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Project.Domain.Entities;
using Project.Infraestructure;
using Proyect.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project.ApiRest.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly IUserRepository _userRepository;
            DataContext _context;

            public UserController(IUserRepository userRepository, DataContext context )
            {
            _userRepository = userRepository;
            _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var product = await _userRepository.GetAll();
                return Ok(product.Where(x => !x.IsDeleted));
            }

            // GET: api/Product/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var product = await _userRepository.GetById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return Ok("User NotExist");
                }

            }

            // POST: api/Product
            [HttpPost]
            public async Task<IActionResult> Create(User user)
            {
                var newUser = new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = user.Role,
                    Telephone = user.Telephone,
                };
                await _userRepository.Create(newUser);
                return Ok(newUser);

            }
  

            // PUT: api/Product/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Put(User user)
            {
                var _user = await _userRepository.GetById(user.Id);


                if (_user != null)
                {
                    _user.UserName = _user.UserName;
                    _user.Password = _user.Password;
                    _user.FirstName = _user.FirstName;
                    _user.LastName = _user.LastName;
                    _user.Email = _user.Email;
                    _user.Role = _user.Role;
                    _user.Telephone = _user.Telephone;

                    await _userRepository.Update(_user);
                    return Ok(_user);
                }
                else
            {
                    return Ok("User NotExist");
                }
            }

            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var _userDelete = await _userRepository.GetById(id);
                if (_userDelete != null)
                {
                    await _userRepository.Delete(_userDelete);
                    return Ok(_userDelete);
                }
                else
                {
                    return Ok("User NotExist");
                }
            }
        }
    
}
