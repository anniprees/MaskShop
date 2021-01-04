using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Data.Parties;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Parties
{
    public class PartiesPage : ViewPage<PartiesPage, IPartiesRepository, Party, PartyView, PartyData>
    {
        public IEnumerable<SelectListItem> PartyType
        {
            get
            {
                return Enum.GetNames(typeof(PartyType)).Select(o => new SelectListItem() { Text = o, Value = o });
            }
        }
        public IEnumerable<SelectListItem> PartyRoles { get; }
        public IEnumerable<SelectListItem> ContactMechanisms { get; }
       
        public PartiesPage(IPartiesRepository r, IPartyRolesRepository p, IContactMechanismsRepository c) :
            base(r, "Parties")
        {
            PartyRoles = CreatePartyRoleSelect(p);
            ContactMechanisms = CreateContactMechanismsSelect(c);
        }

        public string PartyRoleName(string id) => itemName(PartyRoles, id);
        public string ContactMechanismName(string id) => itemName(ContactMechanisms, id);
       

        protected internal override Uri pageUrl() => new Uri("/Shop/Parties", UriKind.Relative);

        protected internal override Party toObject(PartyView v) => PartyViewFactory.Create(v);
        protected internal override PartyView toView(Party o) => PartyViewFactory.Create(o);
        protected internal static IEnumerable<SelectListItem> CreatePartyRoleSelect(IRepository<PartyRole> r)
        {
            var items = r.Get().GetAwaiter().GetResult();
            return items.Select(m => new SelectListItem(m.Data.Role, m.Data.Id)).ToList();
        }

        protected internal static IEnumerable<SelectListItem> CreateContactMechanismsSelect(IRepository<ContactMechanism> c)
        {
            var items = c.Get().GetAwaiter().GetResult();
            return items.Select(m => new SelectListItem(m.Data.ElectronicMail, m.Data.Id)).ToList();
        }

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
