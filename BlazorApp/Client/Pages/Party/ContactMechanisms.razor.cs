using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MaskShop.Facade.Parties;

namespace BlazorApp.Client.Pages.Party
{
    public partial class ContactMechanisms
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        private int totalPagesQuantity = 1;
        private int currentPage = 1;


        List<ContactMechanismView> _contactMechanisms;

        protected ContactMechanismView ContactMechanism = new ContactMechanismView()
        {
            Id ="",
            Street ="",
            City ="",
            State ="",
            Country ="",
            ZipCode = "",
            ElectronicMail ="",
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
            _contactMechanisms = await HttpClient.GetJsonAsync<List<ContactMechanismView>>("api/contactmechanisms");
        }

        //protected async Task LoadPagedData(int page = 1, int pageSize = 10)
        //{
        //    var httpResponse = await HttpClient.GetAsync($"api/contactmechanisms/?page={page}&pageSize={pageSize}");
        //    if (httpResponse.IsSuccessStatusCode)
        //    {
        //        totalPagesQuantity = int.Parse(httpResponse.Headers.GetValues("totalPages").FirstOrDefault());
        //        var responseString = await httpResponse.Content.ReadAsStringAsync();
        //        _contactMechanisms = JsonSerializer.Deserialize<List<ContactMechanismView>>(responseString,
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
                _contactMechanisms = await HttpClient.GetJsonAsync<List<ContactMechanismView>>(("api/contactmechanisms/") + "?name=" + SearchTerm);
                return;
            }

            _contactMechanisms = await HttpClient.GetJsonAsync<List<ContactMechanismView>>(("api/contactmechanisms/") + "?name=" + SearchTerm);
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
            _contactMechanisms = await HttpClient.GetJsonAsync<List<ContactMechanismView>>("api/contactmechanisms/");
            StateHasChanged();
        }
        
        protected void AddContactMechanism()
        {
            this.IsAdd = true;
            this.ModalTitle = "Create contact mechanism";
        }

        protected async Task ViewContactMechanism(string Id)
        {
            ContactMechanism = await HttpClient.GetJsonAsync<ContactMechanismView>("api/contactmechanisms/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.ModalTitle = "View contact mechanism";
        }

        protected async Task EditContactMechanism(string Id)
        {
            ContactMechanism = await HttpClient.GetJsonAsync<ContactMechanismView>("api/contactmechanisms/" + Id);
            SelectedId = Id;
            this.IsAdd = true;
            this.ModalTitle = "Edit contact mechanism";
        }

        protected async Task DeleteContactMechanism(string Id)
        {
            ContactMechanism = await HttpClient.GetJsonAsync<ContactMechanismView>("api/contactmechanisms/" + Id);
            SelectedId = Id;
            this.IsView = true;
            this.IsDelete = true;
            this.ModalTitle = "Delete contact mechanism";
        }

        protected async Task CreateContactMechanism()
        {
            if (SelectedId == null)
            {
                await HttpClient.SendJsonAsync(HttpMethod.Post, "api/contactmechanisms", ContactMechanism);
            }
            else
            {
                await HttpClient.PutJsonAsync("api/contactmechanisms/" + SelectedId, ContactMechanism);
            }

            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemoveContactMechanism()
        {
            await HttpClient.DeleteAsync("api/contactmechanisms/" + SelectedId);
            CloseModal();
            await OnParametersSetAsync();
        }

        protected void CloseModal()
        {
            ContactMechanism = new ContactMechanismView()
            {
                Id = "",
                Street = "",
                City = "",
                State = "",
                Country = "",
                ZipCode = "",
                ElectronicMail = "",
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
