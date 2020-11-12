using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Domain.Common
{
    public abstract class BaseEntity
    {
        public static string Unspecified => Aids.Constants.Word.Unspecified;
        public static DateTime UnspecifiedValidFrom => DateTime.MinValue;
        public static DateTime UnspecifiedValidTo => DateTime.MaxValue;
        public static double UnspecifiedDouble => double.NaN;
        public static decimal UnspecifiedDecimal => decimal.MaxValue;
        public static int UnspecifiedInteger => 0;


    }

}