using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Grid
{
    public interface IFilters
    {
        ProductFilterColumns FilterColumn { get; set; }
        bool Loading { get; set; }
        string FilterText { get; set; }
        IPageHelper PageHelper { get; set; }
        bool SortAscending { get; set; }
        ProductFilterColumns SortColumn { get; set; }
    }
}
