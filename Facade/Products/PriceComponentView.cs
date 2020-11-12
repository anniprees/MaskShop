using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public abstract class PriceComponentView : UniqueEntityView
    {
        [DisplayName("Price")]
        [Required]
        public double Price { get; set; }

        [DisplayName("Percent")]
        [Required]
        public double Percent { get; set; }

        [DisplayName("Comment")]
        [Required]
        public string Comment { get; set; }

        [DisplayName("Product Id")]
        [Required]
        public string ProductId { get; set; }

        [DisplayName("Product feature Id")]
        [Required]
        public string ProductFeatureId { get; set; }

        [DisplayName("Product category Id")]
        [Required]
        public string ProductCategoryId { get; set; }

        [DisplayName("Consumer role type Id")]
        [Required]
        public string ConsumerRoleTypeId { get; set; }
    }
}
