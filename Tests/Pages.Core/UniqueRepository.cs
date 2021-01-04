using MaskShop.Data.Common;
using MaskShop.Domain.Common;

namespace MaskShop.Tests.Pages.Core
{

    internal class UniqueRepository<TObj, TData> : PeriodRepository<TObj, TData>
        where TObj : IEntity<TData>
        where TData : UniqueEntityData, new()
    {

        protected override string getId(TData d) => d.Id;
    }

}