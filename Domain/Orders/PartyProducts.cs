using MaskShop.Data.Orders;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;

namespace MaskShop.Domain.Orders
{
    public abstract class PartyProducts<TData> : DefinedEntity<TData>
    where TData : PartyProductsData, new() 
    {
        protected PartyProducts(TData d) : base(d) { }
        public string PartyId => Data?.PartyId ?? Unspecified;
        public Party Party => new GetFrom<IPartiesRepository, Party>().ById(PartyId);
    }
}
