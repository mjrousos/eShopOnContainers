using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork.Events
{
    public class DomainEventSubscriber<TEvent> : IDomainEventSubscriber<TEvent>
             where TEvent : IDomainEvent
    {
        public DomainEventSubscriber(Action<TEvent> handle)
        {
            this.handle = handle;
        }

        readonly Action<TEvent> handle;

        public void HandleEvent(TEvent domainEvent)
        {
            this.handle(domainEvent);
        }

        public Type SubscribedToEventType()
        {
            return typeof(TEvent);
        }
       
    }
}
