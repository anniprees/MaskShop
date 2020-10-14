using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaskShop.Facade
{
    public abstract class NamedView : UniqueEntityView
    {

        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

    }

}