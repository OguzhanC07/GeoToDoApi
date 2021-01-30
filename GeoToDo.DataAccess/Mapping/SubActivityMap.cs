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
    class SubActivityMap : IEntityTypeConfiguration<SubActivity>
    {
        public void Configure(EntityTypeBuilder<SubActivity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(500);
        }
    }
}
