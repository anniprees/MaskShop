using System;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using MaskShop.PagesCore.Common;

namespace MaskShop.PagesCore.Shop.Parties
{
    public class PartyRolesPage : ViewPage<PartyRolesPage, IPartyRolesRepository, PartyRole, PartyRoleView, PartyRoleData>
    {
        public PartyRolesPage(IPartyRolesRepository r) : base(r, "Roles") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/PartyRoles", UriKind.Relative);

        protected internal override PartyRole toObject(PartyRoleView v) => PartyRoleViewFactory.Create(v);

        protected internal override PartyRoleView toView(PartyRole o) => PartyRoleViewFactory.Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.Role);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

    }
}
