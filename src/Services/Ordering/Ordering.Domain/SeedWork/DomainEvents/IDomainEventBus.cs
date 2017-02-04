using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork.Events
{
    public interface IDomainEventBus
    {
        void Publish<T>(T domainEvent) where T : IDomainEvent;

        void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber);
    }
}
