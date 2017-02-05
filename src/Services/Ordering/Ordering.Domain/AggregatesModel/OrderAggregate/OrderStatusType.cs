using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public enum OrderStatusType { Created, CheckedOut, Canceled, Payed, Shipped, Delivered }

}
