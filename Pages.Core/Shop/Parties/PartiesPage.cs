using System;
using System.Collections.Generic;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Parties
{
    public class PartiesPage : ViewPage<PartiesPage, IPartiesRepository, Party, PartyView, PartyData>
    {
        public IEnumerable<SelectListItem> PartyRoles { get; }
        public IEnumerable<SelectListItem> ContactMechanisms { get; }

        public PartiesPage(IPartiesRepository r, IPartyRolesRepository p, IContactMechanismsRepository c) :
            base(r, "Parties")
        {
            //PartyRoles = newItemsList<PartyRole, PartyRoleData>(p);
            //ContactMechanisms = newItemsList<ContactMechanism, ContactMechanismData>(c);
        }

        public string PartyRoleName(string id) => itemName(PartyRoles, id);
        public string ContactMechanismName(string id) => itemName(ContactMechanisms, id);

        protected internal override Uri pageUrl() => new Uri("/Shop/Parties", UriKind.Relative);

        protected internal override Party toObject(PartyView v) => PartyViewFactory.Create(v);
        protected internal override PartyView toView(Party o) => PartyViewFactory.Create(o);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x => Item.PartyRoleId);
            createColumn(x => Item.ContactMechanismId);
            createColumn(x => Item.PartyType);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

        public override IHtmlContent GetValue(IHtmlHelper<PartiesPage> h, int i) => i switch
        {
            2 => getRaw(h, PartyRoleName(Item.PartyRoleId)),
            3 => getRaw(h, ContactMechanismName(Item.ContactMechanismId)),
            _ => base.GetValue(h, i)

        };
    }
}
