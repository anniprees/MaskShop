using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Parties;
using MaskShop.PagesCore.Shop.Parties;

namespace MaskShop.PagesCore.ShopAdmin.Parties
{
    public class ContactMechanismsAdminPage : ContactMechanismsPage<ContactMechanismsAdminPage>
    {
        public ContactMechanismsAdminPage(IContactMechanismsRepository r) 
            : base(r, "Contacts") { }
        
        protected internal override Uri pageUrl() => new Uri("/Shop/ContactMechanisms", UriKind.Relative);
        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            base.createTableColumns();
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

    }
}
