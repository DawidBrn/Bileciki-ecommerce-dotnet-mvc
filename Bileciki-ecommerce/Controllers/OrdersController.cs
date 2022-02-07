using Bileciki_ecommerce.Data.Services;
using Bileciki_ecommerce.Data.ShoppingCart;
using Bileciki_ecommerce.Data.Test;
using Bileciki_ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bileciki_ecommerce.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _service;
        private readonly ShoppingCart _shoppingCart;
        private readonly ILogger<OrdersController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        public OrdersController(IMoviesService service,ShoppingCart shoppingCart)
        {
            _service = service;
            _shoppingCart = shoppingCart;
           /* _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;*/
        }
        public IActionResult Index()
        {
            //SessionTest session = new SessionTest(_httpContextAccessor);
            //session.setSession();
           // _logger.LogInformation(session.getSession());
            var itemsList = _shoppingCart.GetShoppingCartItems();
            if(itemsList != null)
            _shoppingCart.ShoppingCartItems = itemsList;
            var result = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(result);
        }
    }
}
