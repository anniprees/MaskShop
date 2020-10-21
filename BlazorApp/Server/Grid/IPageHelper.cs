using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Grid
{
    public interface IPageHelper
    {
        int DbPage { get; }
        int Page { get; set; }
        int PrevPage { get; }
        int NextPage { get; }
        bool HasPrev { get; }
        bool HasNext { get; }
        int PageCount { get; }
        int PageItems { get; set; }
        int PageSize { get; set; }
        int Skip { get; }
        int TotalItemCount { get; set; }
    }
}
