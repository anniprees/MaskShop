﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using MaskShop.Facade.Orders;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp.Client.Pages.Basket
{
    public partial class Basket
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }

        [Parameter] public string Page { get; set; } = "1";

        [Parameter] public string SearchTerm { get; set; } = string.Empty;

        BasketItemView[] _basketItems;
        private HubConnection hubConnection;

        protected BasketItemView BasketItem = new BasketItemView { };
        protected OrderItemView OrderItem = new OrderItemView { };
        protected OrderView Order = new OrderView { };

        protected string CurrentBasketItemId { get; set; }
        protected string ModalTitle { get; set; }
        protected bool IsEdit { get; set; }
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
            _basketItems = await HttpClient.GetJsonAsync<BasketItemView[]>("api/basketitems");
            StateHasChanged();
        }

        protected async Task SearchClick()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                _basketItems = await HttpClient.GetJsonAsync<BasketItemView[]>(("api/basketitems/") + "?name=" + SearchTerm);
                return;
            }

            _basketItems = await HttpClient.GetJsonAsync<BasketItemView[]>(("api/basketitems/") + "?name=" + SearchTerm);
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
            _basketItems = await HttpClient.GetJsonAsync<BasketItemView[]>("api/basketitems/");
            StateHasChanged();
        }

        public void Dispose()
        {
            _ = hubConnection.DisposeAsync();
        }

        protected async Task EditBasketItem(string basketItemId)
        {
            BasketItem = await HttpClient.GetJsonAsync<BasketItemView>("api/basketitems/" + basketItemId);
            CurrentBasketItemId = basketItemId;
            this.IsEdit = true;
            this.ModalTitle = "Edit item";
        }

        protected async Task DeleteBasketItem(string basketItemId)
        {
            BasketItem = await HttpClient.GetJsonAsync<BasketItemView>("api/basketitems/" + basketItemId);
            CurrentBasketItemId = basketItemId;
            this.IsDelete = true;
            this.ModalTitle = "Delete item";
        }

        protected async Task UpdateBasketItem()
        {
            await HttpClient.PutJsonAsync("api/basketitems/" + CurrentBasketItemId, BasketItem);
            if (IsConnected) await SendMessage();
            
            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task RemoveBasketItem()
        {
            await HttpClient.DeleteAsync("api/basketitems/" + CurrentBasketItemId);
            if (IsConnected) await SendMessage();
            CloseModal();
            await OnParametersSetAsync();
        }

        protected async Task CreateOrder()
        {
            Order.Id = "1";
            Order.Name = "Order name";
            Order.PartyId = "1";
            Order.PartyNameId = "1";
            Order.ContactMechanismId = "1";
            Order.ValidFrom = DateTime.Now;
            Order.ValidTo = null;

            await HttpClient.PostAsJsonAsync("api/orders", Order);
            await CreateOrderItems();

            if (IsConnected) await SendMessage();
            await OnParametersSetAsync();
        }

        protected async Task CreateOrderItems()
        {
            _basketItems = await HttpClient.GetJsonAsync<BasketItemView[]>("api/basketitems");

            foreach (var basketItem in _basketItems)
            {
                OrderItem.ProductId = basketItem.ProductId;
                OrderItem.OrderId = basketItem.BasketId;
                OrderItem.Quantity = basketItem.Quantity;
                OrderItem.ValidFrom = DateTime.Now;
                OrderItem.ValidTo = null;

                await HttpClient.PostAsJsonAsync("api/orderitems", OrderItem);
            }
        }


        protected void CloseModal()
        {
            BasketItem = new BasketItemView();
            { };
            CurrentBasketItemId = null;
            this.IsEdit = false;
            this.IsDelete = false;
            this.IsDelete = false;
            StateHasChanged();
        }
    }
}
