using System.Net.Http;
using System.Threading.Tasks;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.Pages.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Client.Pages.Products
{
    [Authorize]
    public partial class Products
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }

        [Parameter]
        public string Page { get; set; } = "1";

        [Parameter]
        public string SearchTerm { get; set; } = string.Empty;

        ProductView[] _products;
        private HubConnection hubConnection;

        protected ProductView Product = new ProductView
        {
            Name = "",
            Id = "",
            ProductCategoryId = "",
        };

        protected string CurrentProductId { get; set; }
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
            Task.Run(async () =>
            {
                await LoadData();
            });
        }

        protected async Task LoadData()
        {
            _products = await HttpClient.GetJsonAsync<ProductView[]>("api/products");
            StateHasChanged();
        }

        protected async Task SearchClick()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                _products = await HttpClient.GetJsonAsync<ProductView[]>(("api/products/") + "?name=" + SearchTerm);
                return;
            }

            _products = await HttpClient.GetJsonAsync<ProductView[]>(("api/products/") + "?name=" + SearchTerm);
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
            _products = await HttpClient.GetJsonAsync<ProductView[]>("api/products/");
            StateHasChanged();
        }

        public void Dispose()
        {
            _ = hubConnection.DisposeAsync();
        }

        protected void AddProduct()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create product";
        }

        protected async Task ViewProduct(string productId)
        {
            Product = await HttpClient.GetJsonAsync<ProductView>("api/products/" + productId);
            CurrentProductId = productId;
            this.IsView = true;
            this.ModalTitle = "View product";
        }

        protected async Task EditProduct(string productId)
        {
            Product = await HttpClient.GetJsonAsync<ProductView>("api/products/" + productId);
            CurrentProductId = productId;
            this.IsAdd = true;
            this.ModalTitle = "Edit product";
        }

        protected async Task DeleteProduct(string productId)
        {
            Product = await HttpClient.GetJsonAsync<ProductView>("api/products/" + productId);
            CurrentProductId = productId;
            this.IsView = true;
            this.IsDelete = true;
            this.ModalTitle = "Delete product";
        }


        protected async Task CreateProduct()
        {
            if (CurrentProductId == null)
            {
                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/products", Product);
                if (IsConnected) await SendMessage();
            }
            else
            {
                await HttpClient.PutJsonAsync("api/products/" + CurrentProductId, Product);
                if (IsConnected) await SendMessage();
            }
            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemoveProduct()
        {
            await HttpClient.DeleteAsync("api/products/" + CurrentProductId);
            if (IsConnected) await SendMessage();
            CloseModal();
            await OnParametersSetAsync();
        }

        protected void CloseModal()
        {
            Product = new ProductView
            {
                Name = "",
                Id = "",
                ProductCategoryId = "",
            };
            CurrentProductId = null;
            this.IsAdd = false;
            this.IsView = false;
            this.IsDelete = false;
            StateHasChanged();
        }

        protected void PagerPageChanged(int page)
        {
            NavigationManager.NavigateTo("/productlist/" + page);

        }
    }
}
