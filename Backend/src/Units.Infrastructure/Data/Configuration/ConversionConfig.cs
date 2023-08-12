using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Units.Core;

namespace Units.Infrastructure.Data.Configuration
{
    public class ConversionConfig : IEntityTypeConfiguration<Conversion>
    {
        public void Configure(EntityTypeBuilder<Conversion> builder)
        {
            builder.ToTable("Conversions");
            builder.HasIndex(x => x.Id);
            builder.HasIndex(x => x.Dimension);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Dimension).IsRequired();
            builder.Property(x => x.Units).IsRequired();
            builder.Property(x => x.Factor).IsRequired();

        }

    }
}
