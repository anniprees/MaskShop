using System;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using MaskShop.PagesCore.Common;

namespace MaskShop.PagesCore.Shop.Parties
{
        public class ContactMechanismsPage : ViewPage<ContactMechanismsPage, IContactMechanismsRepository, ContactMechanism, ContactMechanismView, ContactMechanismData>
        {
            public ContactMechanismsPage(IContactMechanismsRepository r) : base(r, "Contacts") { }
            protected internal override Uri pageUrl() => new Uri("/Shop/ContactMechanisms", UriKind.Relative);

            protected internal override ContactMechanism toObject(ContactMechanismView v) => ContactMechanismViewFactory.Create(v);

            protected internal override ContactMechanismView toView(ContactMechanism o) => ContactMechanismViewFactory.Create(o);
            protected override void createTableColumns()
            {
                createColumn(x => Item.Id);
                createColumn(x => Item.Street);
                createColumn(x => Item.City);
                createColumn(x => Item.State);
                createColumn(x => Item.Country);
                createColumn(x => Item.ZipCode);
                createColumn(x => Item.ElectronicMail);
                createColumn(x => Item.ValidFrom);
                createColumn(x => Item.ValidTo);
            }

        }
    }

