using System;
using MaskShop.Data.Common;

namespace MaskShop.Domain.Common
{
    public abstract class NamedEntity<T> : UniqueEntity<T> where T : NamedEntityData, new()
    {

        protected internal NamedEntity(T d = null) : base(d) { }

        public virtual string Name
        {
            get => Data?.Name ?? Unspecified;
            set => throw new NotImplementedException();
        }
    }

}
