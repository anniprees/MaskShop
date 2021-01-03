//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Web;
//using MaskShop.Facade.Parties;
//using MaskShop.Domain.Parties;

//namespace BlazorApp.Client.Pages.Party
//{
//    public partial class PartyNames
//    {
//        [Inject] private HttpClient HttpClient { get; set; }
//        [Parameter] public string SearchTerm { get; set; } = string.Empty;

//        private int totalPagesQuantity = 1;
//        private int currentPage = 1;


//        List<PartyNameView> _partyNames;

//        protected PartyNameView PartyName = new PartyNameView()
//        {
//            Id ="",
//            FirstName = "",
//            MiddleName = "",
//            LastName = "",
//            PartyId = "",
//            ValidFrom = null,
//            ValidTo = null
//        };

//        protected string SelectedId { get; set; }
//        protected string ModalTitle { get; set; }
//        protected bool IsAdd { get; set; }
//        protected bool IsView { get; set; }
//        protected bool IsDelete { get; set; }
        
//        protected override async Task OnParametersSetAsync()
//        {
//            await LoadData();
//        }

//        //private async Task SelectedPage(int page)
//        //{
//        //    currentPage = page;
//        //    await LoadPagedData(page);
//        //}

//        protected async Task LoadData()
//        {
//            _partyNames = await HttpClient.GetJsonAsync<List<PartyNameView>>("api/partynames");
//        }

//        //protected async Task LoadPagedData(int page = 1, int pageSize = 10)
//        //{
//        //    var httpResponse = await HttpClient.GetAsync($"api/partynames/?page={page}&pageSize={pageSize}");
//        //    if (httpResponse.IsSuccessStatusCode)
//        //    {
//        //        totalPagesQuantity = int.Parse(httpResponse.Headers.GetValues("totalPages").FirstOrDefault());
//        //        var responseString = await httpResponse.Content.ReadAsStringAsync();
//        //        _contactMechanisms = JsonSerializer.Deserialize<List<PartyNameView>>(responseString,
//        //            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
//        //    }
//        //    else
//        //    {
//        //        //TODO error handling
//        //    }
//        //}

//        protected async Task SearchClick()
//        {
//            if (string.IsNullOrEmpty(SearchTerm))
//            {
//                _partyNames = await HttpClient.GetJsonAsync<List<PartyNameView>>(("api/partynames/") + "?name=" + SearchTerm);
//                return;
//            }

//            _partyNames = await HttpClient.GetJsonAsync<List<PartyNameView>>(("api/partynames/") + "?name=" + SearchTerm);
//            StateHasChanged();
//        }

//        protected async Task SearchBoxKeyPress(KeyboardEventArgs ev)
//        {
//            if (ev.Key == "Enter")
//            {
//                await SearchClick();
//            }
//        }

//        protected async Task ClearSearch()
//        {
//            SearchTerm = string.Empty;
//            _partyNames = await HttpClient.GetJsonAsync<List<PartyNameView>>("api/partynames/");
//            StateHasChanged();
//        }
        
//        protected void AddPartyName()
//        {
//            this.IsAdd = true;
//            this.ModalTitle = "Create party name";
//        }

//        protected async Task ViewPartyName(string Id)
//        {
//            PartyName = await HttpClient.GetJsonAsync<PartyNameView>("api/partynames/" + Id);
//            SelectedId = Id;
//            this.IsView = true;
//            this.ModalTitle = "View party name";
//        }

//        protected async Task EditPartyName(string Id)
//        {
//            PartyName = await HttpClient.GetJsonAsync<PartyNameView>("api/partynames/" + Id);
//            SelectedId = Id;
//            this.IsAdd = true;
//            this.ModalTitle = "Edit party name";
//        }

//        protected async Task DeletePartyName(string Id)
//        {
//            PartyName = await HttpClient.GetJsonAsync<PartyNameView>("api/partynames/" + Id);
//            SelectedId = Id;
//            this.IsView = true;
//            this.IsDelete = true;
//            this.ModalTitle = "Delete party name";
//        }

//        protected async Task CreatePartyName()
//        {
//            if (SelectedId == null)
//            {
//                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/partynames", PartyName);
//            }
//            else
//            {
//                await HttpClient.PutJsonAsync("api/partynames/" + SelectedId, PartyName);
//            }

//            CloseModal();
//            await OnParametersSetAsync();
//        }

//        protected async Task RemovePartyName()
//        {
//            await HttpClient.DeleteAsync("api/partynames/" + SelectedId);
//            CloseModal();
//            await OnParametersSetAsync();
//        }

//        protected void CloseModal()
//        {
//            PartyName = new PartyNameView()
//            {
//                Id = "",
//                FirstName = "",
//                MiddleName = "",
//                LastName = "",
//                PartyId = "",
//                ValidFrom = null,
//                ValidTo = null
//            };
//            SelectedId = null;
//            this.IsAdd = false;
//            this.IsView = false;
//            this.IsDelete = false;
//            StateHasChanged();
//        }
//    }
//}
