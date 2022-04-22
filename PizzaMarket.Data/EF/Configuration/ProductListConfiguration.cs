using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaMarket.Domain.Model;

namespace PizzaMarket.Infratructure.EF.Configuration
{
    public class ProductListConfiguration : IEntityTypeConfiguration<ProductList>
    {
        public void Configure(EntityTypeBuilder<ProductList> builder)
        {
            builder.HasOne(a => a.Order).WithMany(a => a.ProductList).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Product).WithMany(a => a.ProductList);
            builder.HasKey(a => a.Id);
            builder.Navigation(a => a.Product).AutoInclude();
            builder.Navigation(a => a.Order).AutoInclude();
        }
    }
}
