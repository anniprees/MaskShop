using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Parties;
using MaskShop.PagesCore.Shop.Parties;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopClient.Parties
{
    public class PartiesClientPage : PartiesPage<PartiesClientPage>
    {
        public PartiesClientPage(IPartiesRepository r, IPartyRolesRepository p, IContactMechanismsRepository c) 
            : base(r, p, c, "My data") { }

        protected internal override Uri pageUrl() => new Uri("/Client/Parties", UriKind.Relative);

        public override IHtmlContent GetValue(IHtmlHelper<PartiesClientPage> h, int i) => i switch
        {
            1 => getRaw(h, ContactMechanismName(Item.ContactMechanismId)),
            _ => base.GetValue(h, i)
        };
    }
}
