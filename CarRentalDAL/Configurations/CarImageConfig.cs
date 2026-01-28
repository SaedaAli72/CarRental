using CarRentalDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Configurations
{
    public class CarImageConfig : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .HasMaxLength(36);
           
        }
    }
}
