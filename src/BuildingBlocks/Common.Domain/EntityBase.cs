using System;

namespace Common.Domain
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public long SequentialId { get; protected set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset ModifiedDateTime { get; set; }
    }
}