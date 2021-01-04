﻿using System;
using MaskShop.Aids;

namespace MaskShop.Domain.Common
{
    public abstract class BaseEntity
    {
        public static string Unspecified => Word.Unspecified;
        public static DateTime UnspecifiedValidFrom => DateTime.MinValue;
        public static DateTime UnspecifiedValidTo => DateTime.MaxValue;
        public static double UnspecifiedDouble => double.NaN;
        public static decimal UnspecifiedDecimal => decimal.MaxValue;
        public static int UnspecifiedInteger => 0;
        protected static bool IsUnspecified(string s)
            => string.IsNullOrWhiteSpace(s) || s.Trim() == Unspecified;
    }
}