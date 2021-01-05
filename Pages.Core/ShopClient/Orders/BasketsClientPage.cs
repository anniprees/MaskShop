using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.PagesCore.Shop.Orders;
using Microsoft.AspNetCore.Mvc;

namespace MaskShop.PagesCore.ShopClient.Orders
{
    public class BasketsClientPage : BasketsPage<BasketsClientPage>
    {
        protected override string OrdersPage => "/Shop/Orders";
        public BasketsClientPage(IBasketsRepository r, IOrdersRepository o, IOrderItemsRepository oi) : base(r, o, oi)
        {
        }
        protected internal override Uri pageUrl() => new Uri("/Client/Baskets", UriKind.Relative);

        public override async Task OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            fixedFilter = GetMember.Name<BasketData>(x => x.PartyId);
            fixedValue = User.Identity.Name;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
        }

        public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
            int pageIndex,
            string fixedFilter, string fixedValue)
        {
            var name = GetMember.Name<BasketItemData>(x => x.BasketId);
            var page = "/Client/BasketItems";
            var url = new Uri($"{page}/Index?handler=Index&fixedFilter={name}&fixedValue={id}",
                UriKind.Relative);

            await Task.CompletedTask.ConfigureAwait(false);

            return Redirect(url.ToString());
        }

        protected override void createTableColumns()
        {
            createColumn(x => Item.PartyName);
            createColumn(x => Item.PartyAddress);
            createColumn(x => Item.TotalPrice);
            createColumn(x => Item.ValidFrom);
            //createColumn(x => Item.Closed);
        }

        
    }
}
