using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;

namespace MaskShop.Domain.Common
{
    public abstract class NamedEntity<T> : UniqueEntity<T> where T : NamedEntityData, new()
    {

        protected internal NamedEntity(T d = null) : base(d) { }

        public virtual string Name => Data?.Name ?? Unspecified;

    }

}
