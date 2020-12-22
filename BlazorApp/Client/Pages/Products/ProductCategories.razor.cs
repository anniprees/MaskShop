using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp.Client.Pages.Products
{
    public partial class ProductCategories
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }

        [Parameter] public string Page { get; set; } = "1";

        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        ProductCategoryView[] _categories;
        private HubConnection hubConnection;

        protected ProductCategoryView ProductCategory = new ProductCategoryView
        {
            Id = "",
            Name = "",
            ValidFrom = null,
            ValidTo = null
        };

        protected string CurrentProductCategoryId { get; set; }
        protected string ModalTitle { get; set; }
        protected bool IsAdd { get; set; }
        protected bool IsView { get; set; }
        protected bool IsDelete { get; set; }

        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        Task SendMessage() => hubConnection.SendAsync("SendMessage");

        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/ProductHub"))
                .Build();

            hubConnection.On("ReceiveMessage", () =>
            {
                CallLoadData();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
            await LoadData();
        }

        private void CallLoadData()
        {
            Task.Run(async () => { await LoadData(); });
        }

        protected async Task LoadData()
        {
            _categories = await HttpClient.GetJsonAsync<ProductCategoryView[]>("api/productcategories");
            StateHasChanged();
        }

        protected async Task SearchClick()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                _categories = await HttpClient.GetJsonAsync<ProductCategoryView[]>(("api/productcategories/") + "?name=" + SearchTerm);
                return;
            }

            _categories = await HttpClient.GetJsonAsync<ProductCategoryView[]>(("api/productcategories/") + "?name=" + SearchTerm);
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
            _categories = await HttpClient.GetJsonAsync<ProductCategoryView[]>("api/productcategories/");
            StateHasChanged();
        }

        public void Dispose()
        {
            _ = hubConnection.DisposeAsync();
        }

        protected void AddProductCategory()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create product category";
        }

        protected async Task ViewProductCategory(string productCategoryId)
        {
            ProductCategory = await HttpClient.GetJsonAsync<ProductCategoryView>("api/productcategories/" + productCategoryId);
            CurrentProductCategoryId = productCategoryId;
            this.IsView = true;
            this.ModalTitle = "View product";
        }

        protected async Task EditProductCategory(string productCategoryId)
        {
            ProductCategory = await HttpClient.GetJsonAsync<ProductCategoryView>("api/productcategories/" + productCategoryId);
            CurrentProductCategoryId = productCategoryId;
            this.IsAdd = true;
            this.ModalTitle = "Edit product";
        }

        protected async Task DeleteProductCategory(string productCategoryId)
        {
            ProductCategory = await HttpClient.GetJsonAsync<ProductCategoryView>("api/productcategories/" + productCategoryId);
            CurrentProductCategoryId = productCategoryId;
            this.IsView = true;
            this.IsDelete = true;
            this.ModalTitle = "Delete product";
        }

        protected async Task CreateProductCategory()
        {
            if (CurrentProductCategoryId == null)
            {
                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/productcategories", ProductCategory);
                if (IsConnected) await SendMessage();
            }
            else
            {
                await HttpClient.PutJsonAsync("api/productcategories/" + CurrentProductCategoryId, ProductCategory);
                if (IsConnected) await SendMessage();
            }

            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemoveProductCategory()
        {
            await HttpClient.DeleteAsync("api/productcategories/" + CurrentProductCategoryId);
            if (IsConnected) await SendMessage();
            CloseModal();
            await OnParametersSetAsync();
        }

        protected void CloseModal()
        {
            ProductCategory = new ProductCategoryView(); { };
            CurrentProductCategoryId = null;
            this.IsAdd = false;
            this.IsView = false;
            this.IsDelete = false;
            StateHasChanged();
        }
    }
}
