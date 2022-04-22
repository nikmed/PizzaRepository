using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaMarket.Domain.Model;

namespace PizzaMarket.Infratructure.EF.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(a => a.Customer).WithMany(a => a.Orders);
            builder.Property(a => a.Status).HasConversion<string>();
            builder.Navigation(a => a.ProductList).AutoInclude();
        }
    }
}
