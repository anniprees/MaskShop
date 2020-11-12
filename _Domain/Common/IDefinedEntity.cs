using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Domain.Common
{
    public interface IDefinedEntity : INamedEntity
    {
        string Definition { get; }
    }
    public interface IDefinedEntity<out TData> : IDefinedEntity, IUniqueEntity<TData> { }

}
