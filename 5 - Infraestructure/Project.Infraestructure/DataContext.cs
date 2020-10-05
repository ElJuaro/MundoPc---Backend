using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.MetaData;
using Project.Domain.MetaData.LoginMetaData;
using Project.Infraestructure.Connection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Infraestructure
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StringConnection.GetConnectionStringWin);
            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entidad in ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted
                            && x.OriginalValues.Properties
                                .Any(p => p.Name.Contains("IsDeleted"))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues["IsDeleted"] = true;
            }

            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cascadeFks = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }



            //=============================================================//

            modelBuilder.ApplyConfiguration<Product>(new ProductMetaData());       
            modelBuilder.ApplyConfiguration<User>(new UserMetaData());
           






            //=============================================================//

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
       
        
    }
}
