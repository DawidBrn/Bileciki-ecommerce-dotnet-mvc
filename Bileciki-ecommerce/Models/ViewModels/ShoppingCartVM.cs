using Bileciki_ecommerce.Data.ShoppingCart;

namespace Bileciki_ecommerce.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
