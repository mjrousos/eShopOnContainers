using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork.Events
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent(string source, string version)
        {
            AggregateSource = source;
            Version = version;
            CreatedOn = DateTime.Now;
        }

        public string AggregateSource
        {
            get; private set;
        }

        public DateTime CreatedOn
        {
            get; private set;
        }

        public string Version
        {
            get; private set;
        }
    }
}
