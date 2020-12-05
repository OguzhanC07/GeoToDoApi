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
    public class ActivityMap : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.SelectedTime).IsRequired();
            builder.Property(I => I.ImagePaths).HasMaxLength(500);

            builder.HasOne(I => I.AppUser).WithMany(I => I.Activities).HasForeignKey(I => I.AppUserId);
            builder.HasOne(I => I.ParentActivity).WithMany(I => I.SubActivities).HasForeignKey(I => I.ParentActivityId);
            builder.HasMany(I => I.CategoryActivities).WithOne(I => I.Activity).HasForeignKey(I => I.ActivityId);
        }
    }
}
