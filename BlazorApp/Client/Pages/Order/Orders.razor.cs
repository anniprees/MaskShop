using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Orders;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp.Client.Pages.Order
{
    [Authorize]
    public partial class Orders
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }

        [Parameter] public string Page { get; set; } = "1";

        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        List<OrderView> _orders;
        List<OrderItemView> _orderItems;

        private HubConnection hubConnection;

        protected OrderView Order = new OrderView { };
        protected OrderItemView OrderItem = new OrderItemView { };

        protected string CurrentOrderId { get; set; }
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
            _orders = await HttpClient.GetJsonAsync<List<OrderView>>("api/orders");
            StateHasChanged();
        }

        protected async Task LoadOrderItemsData()
        {
            _orderItems = await HttpClient.GetJsonAsync<List<OrderItemView>>("api/orderitems/" + CurrentOrderId);
            StateHasChanged();
        }

        protected async Task SearchClick()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                _orders = await HttpClient.GetJsonAsync<List<OrderView>>(("api/orders/") + "?name=" + SearchTerm);
                return;
            }

            _orders = await HttpClient.GetJsonAsync<List<OrderView>>(("api/orders/") + "?name=" + SearchTerm);
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
            _orders = await HttpClient.GetJsonAsync<List<OrderView>>("api/orders/");
            StateHasChanged();
        }

        public void Dispose()
        {
            _ = hubConnection.DisposeAsync();
        }


        protected async Task ViewOrder(string orderId)
        {
            CurrentOrderId = orderId;
            await LoadOrderItemsData();
            //OrderItem = await HttpClient.GetJsonAsync<OrderItemView>("api/orderitems/" + orderId);
            this.IsView = true;
            this.ModalTitle = "View order";
        }

        //protected async Task DeleteOrder(string orderId)
        //{
        //    Order = await HttpClient.GetJsonAsync<OrderView>("api/orders/" + orderId);
        //    CurrentOrderId = orderId;
        //    this.IsView = true;
        //    this.IsDelete = true;
        //    this.ModalTitle = "Delete order";
        //}


        //protected async Task RemoveOrder()
        //{
        //    await HttpClient.DeleteAsync("api/orders/" + CurrentOrderId);
        //    if (IsConnected) await SendMessage();
        //    CloseModal();
        //    await OnParametersSetAsync();
        //}

        protected void CloseModal()
        {
            Order = new OrderView { };
            CurrentOrderId = null;
            this.IsAdd = false;
            this.IsView = false;
            this.IsDelete = false;
            StateHasChanged();
        }

    }
}

