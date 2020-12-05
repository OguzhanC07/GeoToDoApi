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
    public class CategoryActivityMap : IEntityTypeConfiguration<CategoryActivity>
    {
        public void Configure(EntityTypeBuilder<CategoryActivity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasIndex(I => new { I.ActivityId, I.CategoryId }).IsUnique();
        }
    }
}
