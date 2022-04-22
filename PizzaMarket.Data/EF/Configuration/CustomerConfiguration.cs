using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaMarket.Domain.Model;

namespace PizzaMarket.Infratructure.EF.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(a => a.Orders).WithOne(a => a.Customer);
            builder.Navigation(a => a.Orders).AutoInclude();
        }
    }
}
