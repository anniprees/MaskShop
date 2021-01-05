using MaskShop.Data.Common;
using MaskShop.Domain.Common;

namespace MaskShop.Tests {

    internal class uniqueRepository<TObj, TData> : periodRepository<TObj, TData>
        where TObj : IEntity<TData>
        where TData : UniqueEntityData, new() {

        protected override string getId(TData d) => d.Id;
    }

}