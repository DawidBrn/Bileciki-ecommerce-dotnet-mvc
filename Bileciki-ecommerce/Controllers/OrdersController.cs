 using Bileciki_ecommerce.Data.Services;
using Bileciki_ecommerce.Data;
using Bileciki_ecommerce.Data.Test;
using Bileciki_ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Bileciki_ecommerce.Models;
using System.Collections.Generic;

namespace Bileciki_ecommerce.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _service;
        private readonly ShoppingCart _shoppingCart;
        private readonly ILogger<OrdersController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private readonly IOrdersService _ordersService;
        public OrdersController(IMoviesService service,ShoppingCart shoppingCart,IOrdersService ordersService)
        {
            _service = service;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
           /* _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;*/
        }
        public async Task<IActionResult> Index()
        {
            string userId = "";

            var orders = await _ordersService.GetAllOrdersAsync(userId);
            if(orders == null) return NotFound();

            return View(orders);
        }
        public  IActionResult ShoppingCart()
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
        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var movie = await _service.GetMovieByIdAsync(id);
            if(movie != null) _shoppingCart.AddItem(movie);
            return RedirectToAction("ShoppingCart");
        }
        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var movie = await _service.GetMovieByIdAsync(id);
            if (movie != null) _shoppingCart.RemoveItem(movie);
            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = string.Empty;
            string userEmail = string.Empty;

            await _ordersService.StoreOrderAsync(items, userId, userEmail);

            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
