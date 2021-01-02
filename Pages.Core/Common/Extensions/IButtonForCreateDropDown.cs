using System;

namespace Pages.Core.Common.Extensions {
    public interface IButtonForCreateDropDown<TPage, TDropDownEnum> {
        int DropDownEntryCount { get; }
        Uri GetDropDownEntryUri(int i);
        string GetDropDownEntryName(int i);
    }
}
