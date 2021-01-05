using System;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using MaskShop.PagesCore.Shop.Parties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopClient.Parties
{
    [Authorize]
    public class PartiesClientPage : PartiesPage<PartiesClientPage>
    {
        protected override string contactsPage => "/Client/ContactMechanisms";
        public PartiesClientPage(IPartiesRepository r, IPartyRolesRepository p, IContactMechanismsRepository c) 
            : base(r, p, c, "My data") { }

        protected internal override Uri pageUrl() => new Uri("/Client/Parties", UriKind.Relative);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new PartyView { Id = User.Identity.Name };
            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public override async Task OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            fixedFilter = GetMember.Name<PartyView>(x => x.Id);
            fixedValue = User.Identity.Name;
            await base.OnGetIndexAsync(sortOrder, id, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }

        public override IHtmlContent GetValue(IHtmlHelper<PartiesClientPage> h, int i) => i switch
        {
            1 => getRaw(h, ContactMechanismName(Item.ContactMechanismId)),
            _ => base.GetValue(h, i)
        };

        public bool HasData()
        {
            var userId = User.Identity.Name;
            var o = db.GetById(userId) as Party;
            return o.Id == userId;
        }
    }
}
