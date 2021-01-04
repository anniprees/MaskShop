using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using MaskShop.PagesCore.Shop.Parties;
using Microsoft.AspNetCore.Authorization;

namespace MaskShop.PagesCore.ShopClient.Parties
{
    [Authorize]
    public class ContactMechanismsClientPage : ContactMechanismsPage<ContactMechanismsClientPage>
    {
        public ContactMechanismsClientPage(IContactMechanismsRepository r) 
            : base(r, "My contacts") { }

        protected internal override Uri pageUrl() => new Uri("/Client/ContactMechanisms", UriKind.Relative);

        public override async Task OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            fixedFilter = GetMember.Name<PartyView>(x => x.Id);
            fixedValue = User.Identity.Name;
            await base.OnGetIndexAsync(sortOrder, id, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }

        public bool HasData()
        {
            var userId = User.Identity.Name;
            var o = db.GetById(userId) as ContactMechanism;
            return o.Id == userId;
        }

    }
}
