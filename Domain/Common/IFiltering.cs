﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Domain.Common
{
    public interface IFiltering
    {
        string SearchString { get; set; }
        string CurrentFilter { get; set; }
        string FixedFilter { get; set; }
        string FIxedValue { get; set; }
    }
}
