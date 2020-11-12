using System;
using MaskShop.Data.Common;

namespace MaskShop.Domain.Common
{
    public abstract class UniqueEntity<T> : Entity<T>, IUniqueEntity<T> where T : UniqueEntityData, new()
    {

        protected internal UniqueEntity(T d = null) : base(d) { }

        public virtual string Id
        {
            get => Data?.Id ?? Unspecified;
            set => throw new NotImplementedException();
        }
    }

}
