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
    public class ActivityImageMap : IEntityTypeConfiguration<ActivityImage>
    {
        public void Configure(EntityTypeBuilder<ActivityImage> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne(I => I.Activity).WithMany(I => I.ActivityImages).HasForeignKey(I => I.ActivityId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
