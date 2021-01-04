using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Parties;
using MaskShop.PagesCore.Shop.Parties;

namespace MaskShop.PagesCore.ShopClient.Parties
{
    public class ContactMechanismsClientPage : ContactMechanismsPage<ContactMechanismsClientPage>
    {
        public ContactMechanismsClientPage(IContactMechanismsRepository r) 
            : base(r, "My contacts") { }

        protected internal override Uri pageUrl() => new Uri("/Client/ContactMechanisms", UriKind.Relative);

    }
}
