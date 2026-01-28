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
    public class UserDocumentConfig :IEntityTypeConfiguration<UserDocument>
    {
        public void Configure(EntityTypeBuilder<UserDocument> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d=> d.Id)
               .IsRequired()
               .HasMaxLength(36);

            builder.Property(d => d.DocumentType)
                .HasConversion<string>();
        }
    }
}
