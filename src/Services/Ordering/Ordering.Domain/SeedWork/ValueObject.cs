using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork
{
  
    public abstract class ValueObject
    {
       internal abstract IEnumerable<object> GetComparisonValues();

        public override bool Equals(object obj)
        {
            if ( this.IsSameObjectReference(obj) ) return true;
            if ( this.IsNull() ) return false;
            if ( !this.IsSameType(obj) ) return false;
            return this.HasSameComparisonValues(obj as ValueObject);
        }
        
        public override int GetHashCode()
        {
            return GetAggregatedHashCode(GetComparisonValues());
        }

        private int GetAggregatedHashCode(IEnumerable<object> objs)
        {
            unchecked
            {
                var hash = 17;
                foreach (var obj in objs)
                    hash = hash * 23 + (obj != null ? obj.GetHashCode() : 0);
                return hash;
            }
        }
    }

    internal static class ValueObjectCompareExtension
    {
        public static bool IsSameObjectReference(this ValueObject vo, object obj)
        {
            return object.ReferenceEquals(vo, obj);
        }

        public static bool IsNull(this ValueObject vo)
        {
            return object.ReferenceEquals(null, vo);
        }

        public static bool IsSameType(this ValueObject vo, object obj)
        {
            return vo.GetType() == obj.GetType();
        }

        public static bool HasSameComparisonValues(this ValueObject vo, ValueObject vo2)
        {
            return vo.GetComparisonValues().SequenceEqual(vo2.GetComparisonValues());
        }
    }
}
