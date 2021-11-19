using Common.Domain;

namespace Core.Domain.AggregatesModel.DeviceTemplate
{
    public class SubCapability : EntityBase
    {
        public ValueSchema Schema { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public long CapabilityId { get; set; }
    }
}