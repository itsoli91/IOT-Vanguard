using Core.Domain.AggregatesModel.DeviceTemplate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Configurations
{
    public class DeviceTemplateConfiguration : IEntityTypeConfiguration<DeviceTemplate>
    {
        public void Configure(EntityTypeBuilder<DeviceTemplate> builder)
        {
            builder.ToTable("DeviceTemplates");
            builder.HasKey(p => p.SequentialId);
            builder.Property(p => p.SequentialId).ValueGeneratedOnAdd();

            builder.HasIndex(p => p.Id).IsUnique();
            builder.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.OwnsOne(s => s.Model, model =>
            {
                model.ToTable("DeviceTemplateModels");
                model.HasIndex(p => p.Id).IsUnique();
                model.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                model.WithOwner().HasForeignKey(fk => fk.DeviceTemplateId);
                model.HasKey(q => q.SequentialId);
                model.OwnsMany(q => q.Capabilities,
                    cap =>
                    {
                        cap.ToTable("Capabilities");
                        cap.HasIndex(p => p.Id).IsUnique();
                        cap.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                        cap.WithOwner().HasForeignKey(s => s.DeviceTemplateModelId);
                        cap.HasKey(ki => ki.SemanticTypeId);
                        cap.HasOne(s => s.CapabilitySemanticType).WithOne();
                        cap.OwnsMany(v => v.SubCapabilities, sb =>
                        {
                            sb.ToTable("SubCapabilities");
                            sb.HasIndex(p => p.Id).IsUnique();
                            sb.Property(p => p.Id).HasDefaultValueSql("gen_random_uuid()");
                            sb.HasKey(kk => kk.SequentialId);
                            sb.WithOwner().HasForeignKey(fik => fik.CapabilityId);
                        });
                    });
            });
        }
    }
}