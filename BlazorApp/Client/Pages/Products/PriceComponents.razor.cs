using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using BlazorApp.Client.Services;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.Pages.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BlazorApp.Client.Pages.Products
{
    public partial class PriceComponents
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        private int totalPagesQuantity = 1;
        private int currentPage = 1;


        List<PriceComponentView> _priceComponents;

        protected PriceComponentView PriceComponent = new PriceComponentView
        {
            Id = "",
            DiscountPercentage = 0,
            Comment = "",
            PartyRoleId = "",
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

        //private async Task SelectedPage(int page)
        //{
        //    currentPage = page;
        //    await LoadPagedData(page);
        //}

        protected async Task LoadData()
        {
            _priceComponents = await HttpClient.GetJsonAsync<List<PriceComponentView>>("api/pricecomponents");
        }

        //protected async Task LoadPagedData(int page = 1, int pageSize = 10)
        //{
        //    var httpResponse = await HttpClient.GetAsync($"api/pricecomponents/?page={page}&pageSize={pageSize}");
        //    if (httpResponse.IsSuccessStatusCode)
        //    {
        //        totalPagesQuantity = int.Parse(httpResponse.Headers.GetValues("totalPages").FirstOrDefault());
        //        var responseString = await httpResponse.Content.ReadAsStringAsync();
        //        _priceComponents = JsonSerializer.Deserialize<List<PriceComponentView>>(responseString,
        //            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //    }
        //    else
        //    {
        //        //TODO error handling
        //    }
        //}

        protected async Task SearchClick()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                _priceComponents = await HttpClient.GetJsonAsync<List<PriceComponentView>>(("api/pricecomponents/") + "?name=" + SearchTerm);
                return;
            }

            _priceComponents = await HttpClient.GetJsonAsync<List<PriceComponentView>>(("api/pricecomponents/") + "?name=" + SearchTerm);
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
            _priceComponents = await HttpClient.GetJsonAsync<List<PriceComponentView>>("api/pricecomponents/");
            StateHasChanged();
        }
        
        protected void AddPriceComponent()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create price component";
        }

        protected async Task ViewPriceComponent(string Id)
        {
            PriceComponent = await HttpClient.GetJsonAsync<PriceComponentView>("api/pricecomponents/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.ModalTitle = "View product";
        }

        protected async Task EditPriceComponent(string Id)
        {
            PriceComponent = await HttpClient.GetJsonAsync<PriceComponentView>("api/pricecomponents/" + Id);
            SelectedId = Id;
            this.IsAdd = true;
            this.ModalTitle = "Edit product";
        }

        protected async Task DeletePriceComponent(string Id)
        {
            PriceComponent = await HttpClient.GetJsonAsync<PriceComponentView>("api/pricecomponents/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.IsDelete = true;
            this.ModalTitle = "Delete product";
        }

        protected async Task CreatePriceComponent()
        {
            if (SelectedId == null)
            {
                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/pricecomponents", PriceComponent);
            }
            else
            {
                await HttpClient.PutJsonAsync("api/pricecomponents/" + SelectedId, PriceComponent);
            }

            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemovePriceComponent()
        {
            await HttpClient.DeleteAsync("api/pricecomponents/" + SelectedId);
            CloseModal();
            await OnParametersSetAsync();
        }

        protected void CloseModal()
        {
            PriceComponent = new PriceComponentView
            {
                Id = "",
                DiscountPercentage = 0,
                Comment = "",
                PartyRoleId = "",
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
