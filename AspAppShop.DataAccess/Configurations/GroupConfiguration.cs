using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace AspAppShop.DataAccess.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name)
                           .HasMaxLength(30)
                           .IsRequired();

            builder.HasIndex(g => g.Name).IsUnique();

            builder.Property(g => g.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
