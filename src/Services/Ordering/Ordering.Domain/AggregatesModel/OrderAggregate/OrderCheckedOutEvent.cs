using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public struct ProductItem
    {
        public int ProductId;
        public int Units;     
    }
         
    public class OrderCheckedOutEvent : DomainEvent
    {
        public OrderCheckedOutEvent(IEnumerable<OrderItem> orderItems) : base("Order","1.0")
        {
            ProductIds = orderItems.Select( p => new ProductItem { ProductId = p.ProductId, Units = p.Units }).ToArray();
        }

        public IReadOnlyCollection<ProductItem> ProductIds
        {
            get; private set;
        }
       
    }
}
