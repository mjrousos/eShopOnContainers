using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork.Events
{
    public class DomainEventBus : IDomainEventBus
    {
        [ThreadStatic]
        private static DomainEventBus _instance = null;

        DomainEventBus()
        {
            this.publishing = false;
        }

        public static DomainEventBus Instance 
        {
            get
            {
                if (_instance == null)
                    _instance = new DomainEventBus();
                return _instance;
            }
        }
        bool publishing;
        List<IDomainEventSubscriber<IDomainEvent>> _subscribers;
        List<IDomainEventSubscriber<IDomainEvent>> Subscribers
        {
            get
            {
                if (this._subscribers == null)
                {
                    this._subscribers = new List<IDomainEventSubscriber<IDomainEvent>>();
                }

                return this._subscribers;
            }
            set
            {
                this._subscribers = value;
            }
        }
        public void Publish<T>(T domainEvent) where T : IDomainEvent
        {
            if (!this.publishing && this.HasSubscribers())
            {
                try
                {
                    this.publishing = true;

                    var eventType = domainEvent.GetType();

                    foreach (var subscriber in this.Subscribers)
                    {
                        var subscribedToType = subscriber.SubscribedToEventType();
                        if (eventType == subscribedToType || subscribedToType == typeof(IDomainEvent))
                        {
                            subscriber.HandleEvent(domainEvent);
                        }
                    }
                }
                finally
                {
                    this.publishing = false;
                }
            }
        }
        public void Reset()
        {
            if (!this.publishing)
            {
                this.Subscribers = null;
            }
        }
        public void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber)
        {
            if (!this.publishing)
            {
                this.Subscribers.Add(subscriber);
            }
        }
        public void Subscribe(Action<IDomainEvent> handle)
        {
            Subscribe(new DomainEventSubscriber<IDomainEvent>(handle));
        }
        bool HasSubscribers()
        {
            return this._subscribers != null && this.Subscribers.Count != 0;
        }
    }
}
