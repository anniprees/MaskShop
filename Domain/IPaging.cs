using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Domain
{
    public interface IPaging
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int TotalPages { get; }
        int HasNextPage { get; }
        int HasPreviousPage { get; }

    }
}
