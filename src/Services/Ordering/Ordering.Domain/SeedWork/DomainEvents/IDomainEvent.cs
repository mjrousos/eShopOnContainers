using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork.Events
{
    public interface IDomainEvent
    {
        string AggregateSource { get; }

        DateTime CreatedOn { get; }

        string Version { get; }

    }
}
