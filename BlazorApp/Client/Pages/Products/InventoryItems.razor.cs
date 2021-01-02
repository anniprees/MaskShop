using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp.Client.Pages.Products
{
    public partial class InventoryItems
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public string SearchTerm { get; set; } = string.Empty;
        
        List<InventoryItemView> _inventoryItems;
        List<ProductView> _products;

        protected InventoryItemView InventoryItem = new InventoryItemView
        {
            Id = "",
            ProductId = "",
            QuantityOnHand = 0,
            ValidFrom = null,
            ValidTo = null
        };

        protected string SelectedId { get; set; }
        protected string ModalTitle { get; set; }
        protected bool IsAdd { get; set; }
        protected bool IsView { get; set; }
        protected bool IsDelete { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await LoadData();
        }
        
        protected async Task LoadData()
        {
            _inventoryItems = await HttpClient.GetJsonAsync<List<InventoryItemView>>("api/inventoryitems");
        }
        
        protected async Task SearchClick()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                _inventoryItems = await HttpClient.GetJsonAsync<List<InventoryItemView>>(("api/inventoryitems/") + "?name=" + SearchTerm);
                return;
            }

            _inventoryItems = await HttpClient.GetJsonAsync<List<InventoryItemView>>(("api/inventoryitems/") + "?name=" + SearchTerm);
            StateHasChanged();
        }

        protected async Task SearchBoxKeyPress(KeyboardEventArgs ev)
        {
            if (ev.Key == "Enter")
            {
                await SearchClick();
            }
        }

        protected async Task ClearSearch()
        {
            SearchTerm = string.Empty;
            _inventoryItems = await HttpClient.GetJsonAsync<List<InventoryItemView>>("api/inventoryitems/");
            StateHasChanged();
        }

        protected async Task AddInventoryItem()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create price component";
            await LoadProductData();
        }

        protected async Task ViewInventoryItem(string Id)
        {
            InventoryItem = await HttpClient.GetJsonAsync<InventoryItemView>("api/inventoryitems/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.ModalTitle = "View product";
        }

        protected async Task EditInventoryItem(string Id)
        {
            InventoryItem = await HttpClient.GetJsonAsync<InventoryItemView>("api/inventoryitems/" + Id);
            SelectedId = Id;
            this.IsAdd = true;
            this.ModalTitle = "Edit product";
            await LoadProductData();
        }

        protected async Task DeleteInventoryItem(string Id)
        {
            InventoryItem = await HttpClient.GetJsonAsync<InventoryItemView>("api/inventoryitems/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.IsDelete = true;
            this.ModalTitle = "Delete product";
        }

        protected async Task CreateInventoryItem()
        {
            if (SelectedId == null)
            {
                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/inventoryitems", InventoryItem);
            }
            else
            {
                await HttpClient.PutJsonAsync("api/inventoryitems/" + SelectedId, InventoryItem);
            }

            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemoveInventoryItem()
        {
            await HttpClient.DeleteAsync("api/inventoryitems/" + SelectedId);
            CloseModal();
            await OnParametersSetAsync();
        }

        protected void CloseModal()
        {
            InventoryItem = new InventoryItemView
            {
                Id = "",
                ProductId = "",
                QuantityOnHand = 0,
                ValidFrom = null,
                ValidTo = null
            };
            SelectedId = null;
            this.IsAdd = false;
            this.IsView = false;
            this.IsDelete = false;
            StateHasChanged();
        }

        protected async Task LoadProductData()
        {
            _products = await HttpClient.GetJsonAsync<List<ProductView>>("api/products");
        }

        private string FindProductName(string id)
        {
            var name = "";
            LoadProductData();
            foreach (var item in _products)
            {
                name = _products.Where(p => p.Id == id).Select(x => x.Name).ToString();
            }
            return name;
        }
    }
}