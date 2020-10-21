using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Grid
{
    public class GridControls : IFilters
    {
        public IPageHelper PageHelper { get; set; }

        public GridControls(IPageHelper pageHelper)
        {
            PageHelper = pageHelper;
        }
        public bool Loading { get; set; }
        public ProductFilterColumns SortColumn { get; set; }
            = ProductFilterColumns.Name;
        public bool SortAscending { get; set; } = true;
        public ProductFilterColumns FilterColumn { get; set; }
            = ProductFilterColumns.Name;
        public string FilterText { get; set; }
    }
}
