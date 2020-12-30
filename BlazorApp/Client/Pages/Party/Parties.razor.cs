using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MaskShop.Facade.Parties;
using MaskShop.Domain.Parties;

namespace BlazorApp.Client.Pages.Party
{
    public partial class Parties
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        private int totalPagesQuantity = 1;
        private int currentPage = 1;


        List<PartyView> _parties;

        protected PartyView Party = new PartyView()
        {
            Id = "",
            PartyNameId = "",
            PartyRoleId = "",
            ContactMechanismId = "",
            PartyType = 0,
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
            _parties = await HttpClient.GetJsonAsync<List<PartyView>>("api/parties");
        }

        //protected async Task LoadPagedData(int page = 1, int pageSize = 10)
        //{
        //    var httpResponse = await HttpClient.GetAsync($"api/parties/?page={page}&pageSize={pageSize}");
        //    if (httpResponse.IsSuccessStatusCode)
        //    {
        //        totalPagesQuantity = int.Parse(httpResponse.Headers.GetValues("totalPages").FirstOrDefault());
        //        var responseString = await httpResponse.Content.ReadAsStringAsync();
        //        _parties = JsonSerializer.Deserialize<List<PartyView>>(responseString,
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
                _parties = await HttpClient.GetJsonAsync<List<PartyView>>(("api/parties/") + "?name=" + SearchTerm);
                return;
            }

            _parties = await HttpClient.GetJsonAsync<List<PartyView>>(("api/parties/") + "?name=" + SearchTerm);
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
            _parties = await HttpClient.GetJsonAsync<List<PartyView>>("api/parties/");
            StateHasChanged();
        }
        
        protected void AddParty()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create party";
        }

        protected async Task ViewParty(string Id)
        {
            Party = await HttpClient.GetJsonAsync<PartyView>("api/parties/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.ModalTitle = "View party";
        }

        protected async Task EditParty(string Id)
        {
            Party = await HttpClient.GetJsonAsync<PartyView>("api/parties/" + Id);
            SelectedId = Id;
            this.IsAdd = true;
            this.ModalTitle = "Edit party";
        }

        protected async Task DeleteParty(string Id)
        {
            Party = await HttpClient.GetJsonAsync<PartyView>("api/parties/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.IsDelete = true;
            this.ModalTitle = "Delete party";
        }

        protected async Task CreateParty()
        {
            if (SelectedId == null)
            {
                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/parties", Party);
            }
            else
            {
                await HttpClient.PutJsonAsync("api/parties/" + SelectedId, Party);
            }

            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemoveParty()
        {
            await HttpClient.DeleteAsync("api/parties/" + SelectedId);
            CloseModal();
            await OnParametersSetAsync();
        }

        protected void CloseModal()
        {
            Party = new PartyView()
            {
                Id = "",
                PartyNameId = "",
                PartyRoleId = "",
                ContactMechanismId = "",
                PartyType = 0,
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
