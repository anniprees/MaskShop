using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp.Client.Pages.Products
{
    public partial class ProductFeatures
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        List<ProductFeatureView> _productFeatures;

        protected ProductFeatureView ProductFeature = new ProductFeatureView
        {
            Id = "",
            Name = "",
            Definition = "",
            NumericCode = 0,
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
            _productFeatures = await HttpClient.GetJsonAsync<List<ProductFeatureView>>("api/productfeatures");
        }

        protected async Task SearchClick()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                _productFeatures = await HttpClient.GetJsonAsync<List<ProductFeatureView>>(("api/productfeatures/") + "?name=" + SearchTerm);
                return;
            }

            _productFeatures = await HttpClient.GetJsonAsync<List<ProductFeatureView>>(("api/productfeatures/") + "?name=" + SearchTerm);
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
            _productFeatures = await HttpClient.GetJsonAsync<List<ProductFeatureView>>("api/productfeatures/");
            StateHasChanged();
        }

        protected void AddProductFeature()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create price component";
        }

        protected async Task ViewProductFeature(string Id)
        {
            ProductFeature = await HttpClient.GetJsonAsync<ProductFeatureView>("api/productfeatures/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.ModalTitle = "View product";
        }

        protected async Task EditProductFeature(string Id)
        {
            ProductFeature = await HttpClient.GetJsonAsync<ProductFeatureView>("api/productfeatures/" + Id);
            SelectedId = Id;
            this.IsAdd = true;
            this.ModalTitle = "Edit product";
        }

        protected async Task DeleteProductFeature(string Id)
        {
            ProductFeature = await HttpClient.GetJsonAsync<ProductFeatureView>("api/productfeatures/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.IsDelete = true;
            this.ModalTitle = "Delete product";
        }

        protected async Task CreateProductFeature()
        {
            if (SelectedId == null)
            {
                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/productfeatures", ProductFeature);
            }
            else
            {
                await HttpClient.PutJsonAsync("api/productfeatures/" + SelectedId, ProductFeature);
            }

            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemoveProductFeature()
        {
            await HttpClient.DeleteAsync("api/productfeatures/" + SelectedId);
            CloseModal();
            await OnParametersSetAsync();
        }

        protected void CloseModal()
        {
            ProductFeature = new ProductFeatureView
            {
                Id = "",
                Name = "",
                Definition = "",
                NumericCode = 0,
                ValidFrom = null,
                ValidTo = null
            };
            SelectedId = null;
            this.IsAdd = false;
            this.IsView = false;
            this.IsDelete = false;
            StateHasChanged();
        }
    }
}