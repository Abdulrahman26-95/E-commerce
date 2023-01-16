using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(300);
            builder.Property(p => p.photoUrl).IsRequired().HasMaxLength(225);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(b => b.ProductBrandId);
            // builder.HasData(
            //     new ProductBrand { Id = 1, Name = "SamSung" },
            //     new ProductBrand { Id = 2, Name = "Apple" },
            //     new ProductBrand { Id = 3, Name = "LG" },
            //     new ProductBrand { Id = 4, Name = "Panasonic" },
            //     new ProductBrand { Id = 5, Name = "Toshipa" },
            //     new ProductBrand { Id = 6, Name = "Oppo" });
            builder.HasOne(b => b.ProductType).WithMany().HasForeignKey(b => b.ProductTypeId);
            // builder.HasData(
            //     new ProductType { Id = 1, Name = "Mobiles" },
            //     new ProductType { Id = 2, Name = "Labtops" },
            //     new ProductType { Id = 3, Name = "Screens" },
            //     new ProductType { Id = 4, Name = "Airpods" }
            // );
        }
    }
}