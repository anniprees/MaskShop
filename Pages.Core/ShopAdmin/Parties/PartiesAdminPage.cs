using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Parties;
using MaskShop.PagesCore.Shop.Parties;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopAdmin.Parties
{
    public class PartiesAdminPage : PartiesPage<PartiesAdminPage>
    {
        public PartiesAdminPage(IPartiesRepository r, IPartyRolesRepository p, IContactMechanismsRepository c) 
            : base(r, p, c, "Users data") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/Parties", UriKind.Relative);
        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.PartyType);
            createColumn(x => Item.PartyRoleId);
            base.createTableColumns();
            createColumn(x => Item.ValidTo);
        }

        public override IHtmlContent GetValue(IHtmlHelper<PartiesAdminPage> h, int i) => i switch
        {
            2 => getRaw(h, PartyRoleName(Item.PartyRoleId)),
            4 => getRaw(h, ContactMechanismName(Item.ContactMechanismId)),
            _ => base.GetValue(h, i)

        };
    }
}
