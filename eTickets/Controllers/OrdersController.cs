using eTickets.Data.Base.BaesInterFaces;
using eTickets.Data.Cart;
using eTickets.Data.Services.InterFaces;
using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IunitOfWork _unitOfWork;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _orderService;

        public OrdersController(IunitOfWork unitOfWork, ShoppingCart shoppingCart, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items;
            var responce = new ShopingCartVM()
            {
                shoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(responce);
        }


        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _unitOfWork.MoviesServices.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddMovieToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }


        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _unitOfWork.MoviesServices.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.removeItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> CopmletOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmail = User.FindFirstValue(ClaimTypes.Email);

            await _orderService.storeOrderAsyns(items, userId, userEmail);

            await _shoppingCart.clearShoppingCartAsync();
            

            return View("OrderCompleted");


        }
    }
}
