using System;
using MaskShop.Data.Common;

namespace MaskShop.Domain.Common
{
    public abstract class Entity<TData> : ValueObject<TData>, IEntity<TData> where TData : PeriodData, new()
    {


        protected internal Entity(TData d = null) : base(d) { }

        public virtual DateTime ValidFrom
        {
            get => Data?.ValidFrom ?? UnspecifiedValidFrom;
            set => throw new NotImplementedException();
        }

        public virtual DateTime ValidTo
        {
            get => Data?.ValidTo ?? UnspecifiedValidTo;
            set => throw new NotImplementedException();
        }
    }

}
