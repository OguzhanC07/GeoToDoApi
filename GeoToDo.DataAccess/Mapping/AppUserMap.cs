using GeoToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.DataAccess.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.UserName).HasMaxLength(50).IsRequired();
            builder.HasIndex(I => I.UserName).IsUnique();
            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();
            builder.HasIndex(I => I.Email).IsUnique();
            builder.Property(I => I.Email).HasMaxLength(100).IsRequired();

            builder.Property(I => I.Name).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Surname).HasMaxLength(50).IsRequired();

            builder.HasMany(I => I.AppUserRoles).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId);

        }
    }
}
