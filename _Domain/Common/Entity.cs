using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;

namespace MaskShop.Domain.Common
{
    public abstract class Entity<TData> : ValueObject<TData>, IEntity<TData> where TData : PeriodData, new()
    {


        protected internal Entity(TData d = null) : base(d) { }

        public virtual DateTime ValidFrom => Data?.From ?? UnspecifiedValidFrom;

        public virtual DateTime ValidTo => Data?.To ?? UnspecifiedValidTo;
    }

}
