using Bileciki_ecommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bileciki_ecommerce.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
        Task <IEnumerable<Order>> GetAllOrdersAsync(string userId);
    }
}
