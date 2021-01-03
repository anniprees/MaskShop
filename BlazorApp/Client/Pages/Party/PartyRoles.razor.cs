using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MaskShop.Facade.Parties;

namespace BlazorApp.Client.Pages.Party
{
    public partial class PartyRoles
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        private int totalPagesQuantity = 1;
        private int currentPage = 1;


        List<PartyRoleView> _partyRoles;

        protected PartyRoleView PartyRole = new PartyRoleView()
        {
            Id ="",
            Role = "",
            //PartyId = "",
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
            _partyRoles = await HttpClient.GetJsonAsync<List<PartyRoleView>>("api/partyroles");
        }

        //protected async Task LoadPagedData(int page = 1, int pageSize = 10)
        //{
        //    var httpResponse = await HttpClient.GetAsync($"api/partyroles/?page={page}&pageSize={pageSize}");
        //    if (httpResponse.IsSuccessStatusCode)
        //    {
        //        totalPagesQuantity = int.Parse(httpResponse.Headers.GetValues("totalPages").FirstOrDefault());
        //        var responseString = await httpResponse.Content.ReadAsStringAsync();
        //        _partyroles = JsonSerializer.Deserialize<List<PartyRoleView>>(responseString,
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
                _partyRoles = await HttpClient.GetJsonAsync<List<PartyRoleView>>(("api/partyroles/") + "?name=" + SearchTerm);
                return;
            }

            _partyRoles = await HttpClient.GetJsonAsync<List<PartyRoleView>>(("api/partyroles/") + "?name=" + SearchTerm);
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
            _partyRoles = await HttpClient.GetJsonAsync<List<PartyRoleView>>("api/partyroles/");
            StateHasChanged();
        }
        
        protected void AddPartyRole()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create party role";
        }

        protected async Task ViewPartyRole(string Id)
        {
            PartyRole = await HttpClient.GetJsonAsync<PartyRoleView>("api/partyroles/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.ModalTitle = "View party role";
        }

        protected async Task EditPartyRole(string Id)
        {
            PartyRole = await HttpClient.GetJsonAsync<PartyRoleView>("api/partyroles/" + Id);
            SelectedId = Id;
            this.IsAdd = true;
            this.ModalTitle = "Edit party role";
        }

        protected async Task DeletePartyRole(string Id)
        {
            PartyRole = await HttpClient.GetJsonAsync<PartyRoleView>("api/partyroles/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.IsDelete = true;
            this.ModalTitle = "Delete party role";
        }

        protected async Task CreatePartyRole()
        {
            if (SelectedId == null)
            {
                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/partyroles", PartyRole);
            }
            else
            {
                await HttpClient.PutJsonAsync("api/partyroles/" + SelectedId, PartyRole);
            }

            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemovePartyRole()
        {
            await HttpClient.DeleteAsync("api/partyroles/" + SelectedId);
            CloseModal();
            await OnParametersSetAsync();
        }

        protected void CloseModal()
        {
            PartyRole = new PartyRoleView()
            {
                Id = "",
                Role = "",
                //PartyId = "",
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
