using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.Facade.Orders;
using MaskShop.Facade.Products;
using MaskShop.Infra.Orders;
using MaskShop.PagesCore.ShopClient.Products;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.CoreIdentity.Components
{
    public partial class Products
    {
        //[Inject] private NavigationManager NavigationManager { get; set; }
        //[Inject] private HttpClient HttpClient { get; set; }

        [Parameter] public List<ProductView> Items { get; set; }
        [Parameter] public IBasketsRepository Baskets { get; set; }
        [Parameter] public IBasketItemsRepository BasketItems { get; set; }
        [Parameter] public IProductsRepository ProductsRepo { get; set; }

        private HubConnection hubConnection;

        protected ProductView Product = new ProductView
        {
            Name = "",
            Id = "",
            ProductCategoryId = "",
            Price = 0,
            PictureFile = null,
            PriceComponentId = "",
            PictureUri = null,
            ValidFrom = null,
            ValidTo = null
        };

        protected BasketItemView BasketItem = new BasketItemView { };

        protected string CurrentProductId { get; set; }
        protected string ModalTitle { get; set; }
        protected bool IsView { get; set; }

        protected async Task AddToBasket(string productId)
        {
            //Product p = await ProductsRepo.Get(productId);
            //Basket b = await Baskets.GetLatestForUser(User.Identity.Name);
            //BasketItem i = await BasketItems.Add(b, p);
        }

        //public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        //Task SendMessage() => hubConnection.SendAsync("SendMessage");

        //protected override async Task OnInitializedAsync()
        //{
        //    hubConnection = new HubConnectionBuilder()
        //        .WithUrl(NavigationManager.ToAbsoluteUri("/ProductHub"))
        //        .Build();

        //    hubConnection.On("ReceiveMessage", () =>
        //    {
        //        CallLoadData();
        //        StateHasChanged();
        //    });

        //    await hubConnection.StartAsync();
        //    await LoadData();
        //}

        //private void CallLoadData()
        //{
        //    Task.Run(async () => { await LoadData(); });
        //}

        //protected async Task LoadData()
        //{
        //    _products = await HttpClient.GetJsonAsync<List<ProductView>>("api/products");
        //    StateHasChanged();
        //}

        //protected async Task LoadCategoriesData()
        //{
        //    _categories = await HttpClient.GetJsonAsync<ProductCategoryView[]>("api/productcategories");
        //}

        //protected async Task SearchClick()
        //{
        //    if (string.IsNullOrEmpty(SearchTerm))
        //    {
        //        Items = await HttpClient.GetJsonAsync<List<ProductView>>(("api/products/") + "?name=" + SearchTerm);
        //        return;
        //    }

        //    Items = await HttpClient.GetJsonAsync<List<ProductView>>(("api/products/") + "?name=" + SearchTerm);
        //    StateHasChanged();
        //}

        //protected async Task SearchBoxKeyPress(KeyboardEventArgs ev)
        //{
        //    if (ev.Key == "Enter")
        //    {
        //        await SearchClick();
        //    }
        //}

        //protected async Task ClearSearch()
        //{
        //    SearchTerm = string.Empty;
        //    _products = await HttpClient.GetJsonAsync<List<ProductView>>("api/products/");
        //    StateHasChanged();
        //}

        //public void Dispose()
        //{
        //    _ = hubConnection.DisposeAsync();
        //}

        //async Task OnFileChange(InputFileChangeEventArgs e)
        //{
        //    var format = "image/png";
        //    var resizedImage = await e.File.RequestImageFileAsync(format, 300, 300);
        //    var buffer = new byte[resizedImage.Size];
        //    await resizedImage.OpenReadStream().ReadAsync(buffer);
        //    var imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
        //    Product.PictureUri = imageData;
        //}

        //protected async Task ViewProduct(string productId)
        //{
        //    Product = await HttpClient.GetJsonAsync<ProductView>("api/products/" + productId);
        //    CurrentProductId = productId;
        //    this.IsView = true;
        //    this.ModalTitle = "View product";
        //}

        //protected async Task EditProduct(string productId)
        //{
        //    Product = await HttpClient.GetJsonAsync<ProductView>("api/products/" + productId);
        //    CurrentProductId = productId;
        //    this.IsAdd = true;
        //    this.ModalTitle = "Edit product";
        //    await LoadCategoriesData();
        //}

        //protected async Task CreateBasketItem()
        //{
        //    BasketItem.ProductId = CurrentProductId;
        //    BasketItem.Quantity = 1;
        //    BasketItem.BasketId = "1";

        //    //await HttpClient.PutJsonAsync("api/basketitems/", BasketItem);
        //    await HttpClient.PostAsJsonAsync("api/basketitems", BasketItem);
        //    //await HttpClient.SendJsonAsync(HttpMethod.Post, "api/basketitems", BasketItem);
        //    if (IsConnected) await SendMessage();
        //    CloseModal();
        //    await OnParametersSetAsync();
        //}

        //protected void CloseModal()
        //{
        //    Product = new ProductView { };
        //    CurrentProductId = null;
        //    this.IsAdd = false;
        //    this.IsView = false;
        //    this.IsDelete = false;
        //    StateHasChanged();
        //}

        //protected async Task FilterCategory(ChangeEventArgs eventArgs)
        //{
        //    if (eventArgs.Value.ToString() == "-1")
        //        return;

        //    var filteredList = await HttpClient.GetJsonAsync<List<ProductView>>("api/products");
        //    _products = filteredList.Where(p => p.ProductCategoryId.Equals(eventArgs.Value.ToString())).ToList();

        //    StateHasChanged();
        //}
    }
}
