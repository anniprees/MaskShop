using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Client.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Client.Components
{
    public class DropdownListBase : ComponentBase
    {
        public List<Masks> masksList { get; set; }
        public string Id = string.Empty;

        public DropdownListBase dropdownList = new DropdownListBase();

        protected override Task OnInitializedAsync()
        {
            masksList = new List<Masks>()
            {
                new Masks {MaskId = 0, Title = "Mask 1"},
                new Masks {MaskId = 1, Title = "Mask 2"},
                new Masks {MaskId = 2, Title = "Mask 3"},
            };
            return base.OnInitializedAsync();
        }
    }
}
