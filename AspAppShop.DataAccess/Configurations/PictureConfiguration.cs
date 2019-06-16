using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace AspAppShop.DataAccess.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(pc => pc.Route)
                .IsRequired();
            builder.Property(pc => pc.Descritption)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(pc => pc.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(pc => pc.PictureProducts)
               .WithOne(pcp => pcp.Picture)
               .HasForeignKey(pcp => pcp.PictureId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
