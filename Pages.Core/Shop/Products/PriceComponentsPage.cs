using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Products
{
    public class PriceComponentsPage : ViewPage<PriceComponentsPage, IPriceComponentsRepository, PriceComponent,
        PriceComponentView, PriceComponentData>
    {
        public IEnumerable<SelectListItem> PartyRoles { get; }

        public PriceComponentsPage(IPriceComponentsRepository r, IPartyRolesRepository p) :
            base(r, "Price Discounts")
        {
            PartyRoles = CreatePartyRoleSelect(p);
        }

        public string PartyRoleName(string id) => itemName(PartyRoles, id);

        protected internal override Uri pageUrl() => new Uri("/Shop/PriceComponents", UriKind.Relative);

        protected internal override PriceComponent toObject(PriceComponentView v) =>
            PriceComponentViewFactory.Create(v);

        protected internal override PriceComponentView toView(PriceComponent o) => PriceComponentViewFactory.Create(o);

        protected internal static IEnumerable<SelectListItem> CreatePartyRoleSelect(IRepository<PartyRole> r)
        {
            var items = r.Get().GetAwaiter().GetResult();
            return items.Select(m => new SelectListItem(m.Data.Id, m.Data.Id)).ToList();
        }

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.Comment);
            createColumn(x => Item.DiscountPercentage);
            createColumn(x => Item.PartyRoleId);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override IHtmlContent GetValue(IHtmlHelper<PriceComponentsPage> h, int i) => i switch
        {
            3 => getRaw(h, PartyRoleName(Item.PartyRoleId)),
           _ => base.GetValue(h, i)

        };
    }
}
        