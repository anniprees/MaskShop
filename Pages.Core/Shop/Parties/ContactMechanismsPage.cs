using System;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaskShop.PagesCore.Shop.Parties
{
        public abstract class ContactMechanismsPage<TPage> 
            : ViewPage<TPage, IContactMechanismsRepository, ContactMechanism, ContactMechanismView, ContactMechanismData> 
            where TPage : PageModel
        {
            protected ContactMechanismsPage(IContactMechanismsRepository r, string title) : base(r, title) { }
            protected internal override ContactMechanism toObject(ContactMechanismView v) => ContactMechanismViewFactory.Create(v);
            protected internal override ContactMechanismView toView(ContactMechanism o) => ContactMechanismViewFactory.Create(o);
            protected override void createTableColumns()
            {
                createColumn(x => Item.Street);
                createColumn(x => Item.City);
                createColumn(x => Item.State);
                createColumn(x => Item.Country);
                createColumn(x => Item.ZipCode);
                createColumn(x => Item.ElectronicMail);
            }

        }
    }

