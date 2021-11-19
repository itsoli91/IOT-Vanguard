using System.Collections.Generic;
using Core.Domain.AggregatesModel.DeviceTemplate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Configurations
{
    public class SemanticTypeConfiguration : IEntityTypeConfiguration<SemanticType>
    {
        public void Configure(EntityTypeBuilder<SemanticType> builder)
        {
            builder.ToTable("SemanticTypes");
            builder.HasKey(p => p.SequentialId);
            builder.Property(p => p.SequentialId).ValueGeneratedOnAdd();
            builder.HasIndex(p => p.Id).IsUnique();
            builder.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(s => s.Schemas).HasConversion<List<string>>();
            builder.Property(s => s.Units).HasConversion<List<string>>();
        }
    }
}