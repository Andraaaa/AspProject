using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace AspAppShop.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Address)
              .HasMaxLength(40)
              .IsRequired();
            builder.Property(o => o.City)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(o => o.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(o => o.OrderProducts)
               .WithOne(op => op.Order)
               .HasForeignKey(op => op.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
