using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Data.Parties;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Parties
{
    public abstract class PartiesPage<TPage> : 
        ViewPage<TPage, IPartiesRepository, Party, PartyView, PartyData> 
        where TPage : PageModel
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
       
        public PartiesPage(IPartiesRepository r, IPartyRolesRepository p, IContactMechanismsRepository c, string title) :
            base(r, title)
        {
            PartyRoles = CreatePartyRoleSelect(p);
            ContactMechanisms = CreateContactMechanismsSelect(c);
        }

        public string PartyRoleName(string id) => itemName(PartyRoles, id);
        public string ContactMechanismName(string id) => itemName(ContactMechanisms, id);

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
            createColumn(x => Item.Name);
            createColumn(x => Item.ContactMechanismId);
            createColumn(x => Item.ValidFrom);
        }
    }
}
