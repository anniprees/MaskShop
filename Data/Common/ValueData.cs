using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaskShop.Data.Common
{
    [ComplexType]
    public sealed class ValueData
    {
        public string UnitOrCurrencyId { get; set; }
        public string Value { get; set; }
        //public ValueType ValueType { get; set; }
        //public DateTime? From { get; set; }
    }
}
