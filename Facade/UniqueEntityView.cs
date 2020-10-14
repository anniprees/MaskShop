using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaskShop.Facade
{
    public abstract class UniqueEntityView : PeriodView
    {

        [Required]
        public string Id { get; set; }

        public override string GetId() => Id;

    }

}