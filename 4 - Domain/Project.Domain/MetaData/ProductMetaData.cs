using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.MetaData
{
    public class ProductMetaData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Codigo)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.SalePrice)
                .IsRequired();

            builder.Property(x => x.Stock)
                .HasMaxLength(200)
                .IsRequired();
        
        }
    }
}
