using System;
using System.Collections.Generic;
using MaskShop.Data.Products;
using MaskShop.Domain.Parties;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
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
            //TODO PartyRoles SelectItem
            //PartyRoles = newItemsList<PartyRole, PartyRoleData>(p);
        }

        public string PartyRoleName(string id) => itemName(PartyRoles, id);

        protected internal override Uri pageUrl() => new Uri("/Shop/PriceComponents", UriKind.Relative);

        protected internal override PriceComponent toObject(PriceComponentView v) =>
            PriceComponentViewFactory.Create(v);

        protected internal override PriceComponentView toView(PriceComponent o) => PriceComponentViewFactory.Create(o);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.Comment);
            createColumn(x => Item.DiscountPercentage);
            createColumn(x => Item.PartyRoleId);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
    }
}
        