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
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(c => c.Status)
                .HasConversion<string>();

            builder.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");

            builder.ToTable(option =>
            {
                option.HasCheckConstraint("status_car_constr", "UPDATE c " +
                    "SET c.Status = 'Available' " +
                    "FROM Cars c " +
                    "INNER JOIN Rentals r " +
                    "ON c.Id = r.CarId " +
                    "WHERE r.ActualDate IS NOT NULL AND c.Status <> 'Available';");
            });
        }
    }
}
