using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MaskShop.Aids.Constants;
using MaskShop.Data.Common;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorApp.Client.Pages.Products
{
    [Authorize]
    public partial class Products
    {

        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }

        [Parameter] public string Page { get; set; } = "1";

        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        ProductView[] _products;
        ProductCategoryView[] _categories;

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
            ProductFeatureApplicabilityId = null,
            ValidFrom = null,
            ValidTo = null
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
            Task.Run(async () => { await LoadData(); });
        }

        protected async Task LoadData()
        {
            _products = await HttpClient.GetJsonAsync<ProductView[]>("api/products");
            StateHasChanged();
        }

        protected async Task LoadCategoriesData()
        {
            _categories = await HttpClient.GetJsonAsync<ProductCategoryView[]>("api/productcategories");
            //StateHasChanged();
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

        async Task OnFileChange(InputFileChangeEventArgs e)
        {
            var format = "image/png";
            var resizedImage = await e.File.RequestImageFileAsync(format, 300, 300);
            var buffer = new byte[resizedImage.Size];
            await resizedImage.OpenReadStream().ReadAsync(buffer);
            var imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
            Product.PictureUri = imageData;
        }

        protected async Task AddProduct()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create product";
            await LoadCategoriesData();
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
            await LoadCategoriesData();
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
            Product = new ProductView { };
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

        //public IEnumerable<SelectListItem> ProductCategory { get; }

        //public Products(IProductsRepository a, IProductCategoriesRepository b)
        //{
        //    ProductCategory = NewItemsList<ProductCategory, ProductCategoryData>(b);
        //}

        //public string CategoryName(string id) => ItemName(ProductCategory, id);

        //public List<LambdaExpression> Columns { get; }
        //    = new List<LambdaExpression>();

        //public ProductView Item { get; set; }


        //protected internal static IEnumerable<SelectListItem> NewItemsList<TTDomain, TTData>(
        //    IRepository<TTDomain> r,
        //    Func<TTDomain, bool> condition = null,
        //    Func<TTData, string> getName = null)
        //    where TTDomain : IEntity<TTData>
        //    where TTData : NamedEntityData, new()
        //{
        //    Func<TTData, string> name = d => (getName is null) ? d.Name : getName(d);
        //    var items = r?.Get().GetAwaiter().GetResult();
        //    var l = items is null
        //        ? new List<SelectListItem>()
        //        : condition is null ?
        //            items
        //                .Select(m => new SelectListItem())
        //                .ToList() :
        //            items
        //                .Where(condition)
        //                .Select(m => new SelectListItem())
        //                .ToList();
        //    l.Insert(0, new SelectListItem());
        //    return l;
        //}

        //protected internal static IEnumerable<SelectListItem> NewCategoryList<TTDomain, TTData>(
        //    IRepository<TTDomain> r)
        //    where TTDomain : Entity<TTData>
        //    where TTData : NamedEntityData, new()
        //{
        //    var items = r?.Get().GetAwaiter().GetResult();
        //    return items.Select(m => new SelectListItem()).ToList();
        //}

        //protected internal static string ItemName(IEnumerable<SelectListItem> list, string id)
        //{
        //    if (list is null) return Word.Unspecified;

        //    foreach (var m in list)
        //        if (m.Value == id)
        //            return m.Text;

        //    return Word.Unspecified;
        //}

        //protected IHtmlContent GetRaw<TResult>(IHtmlHelper h, TResult r) => h.Raw(r.ToString());

        //private bool IsCorrectIndex<TList>(int i, IList<TList> l) => i >= 0 && i < l?.Count;

        //public string Undefined => "Undefined";

        //protected string getName<TResult>(IHtmlHelper<Products> h, int i)
        //{
        //    if (IsCorrectIndex(i, Columns))
        //        return h.DisplayNameFor(Columns[i] as Expression<Func<Products, TResult>>);
        //    return Undefined;
        //}

        //protected IHtmlContent getValue<TResult>(IHtmlHelper<Products> h, int i)
        //{
        //    if (IsCorrectIndex(i, Columns))
        //        return h.DisplayFor(Columns[i] as Expression<Func<Products, TResult>>);
        //    return null;
        //}

        //public string GetName(IHtmlHelper<Products> h, int i) => i switch
        //{
        //    4 => getName<decimal>(h, i),
        //    8 | 9 => getName<DateTime?>(h, i),
        //    _ => GetName(h, i)
        //};

        //public IHtmlContent GetValue(IHtmlHelper<Products> h, int i) => i switch
        //{
        //    4 => getValue<decimal>(h, i),
        //    6 => GetRaw(h, (Item.ProductCategoryId)),
        //    8 | 9 => getValue<DateTime?>(h, i),
        //    _ => GetValue(h, i)
        //};
    }

}
