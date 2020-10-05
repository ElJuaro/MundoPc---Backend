using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Entities;
using Project.Infraestructure;
using Project.Infraestructure.Repository;
using Proyect.Implementation;
using Proyect.Interface;
using System;

namespace Project.Inyection
{
    public class Injection
    {
        public static void ConfigurationServices(IServiceCollection servicios)
        {
            servicios.AddDbContext<DataContext>();

            servicios.AddTransient<IProductRepository, ProductRepository>();
            servicios.AddTransient<IRepository<Product>, Repository<Product>>();

            servicios.AddTransient<IUserRepository, UserRepository>();
            servicios.AddTransient<IRepository<User>, Repository<User>>();

        }
    }
}
