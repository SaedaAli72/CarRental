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
    public class PaymentConfig:IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(p => p.PaymentType)
                .HasConversion<string>();
        }
    }
}
