using System.Collections.Generic;
using Common.Domain;

namespace Core.Domain.AggregatesModel.DeviceTemplate
{
    public class SemanticType : EntityBase
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsComplex { get; set; }
        public List<Schema> Schemas { get; set; }
        public List<Unit> Units { get; set; }
    }
}