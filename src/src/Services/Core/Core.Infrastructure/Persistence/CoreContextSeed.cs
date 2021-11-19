using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.AggregatesModel.DeviceTemplate;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Persistence
{
    public class CoreContextSeed
    {
        public static async Task SeedAsync(CoreContext coreContext, ILogger<CoreContextSeed> logger)
        {
            if (!coreContext.SemanticTypes.Any())
            {
                coreContext.SemanticTypes.AddRange(GetPreconfiguredSemanticTypes());
            }

            if (!coreContext.DeviceTemplates.Any())
            {
                coreContext.DeviceTemplates.AddRange(GetPreconfiguredDeviceTemplates());
            }

            await coreContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}",
                nameof(CoreContext));
        }

        private static IEnumerable<SemanticType> GetPreconfiguredSemanticTypes()
        {
            return new List<SemanticType>
            {
                new()
                {
                   
                }
            };
        }

        private static IEnumerable<DeviceTemplate> GetPreconfiguredDeviceTemplates()
        {
            return new List<DeviceTemplate>
            {
                new()
                {
                   
                }
            };
        }
    }
}