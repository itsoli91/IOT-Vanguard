using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Domain;
using Core.Domain.AggregatesModel.DeviceTemplate;
using Core.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeviceTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new SemanticTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DeviceTemplate> DeviceTemplates { get; set; }
        public DbSet<SemanticType> SemanticTypes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDateTime = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDateTime = DateTime.Now;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}