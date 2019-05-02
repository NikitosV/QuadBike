using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.ShoppingViewModel;

namespace QuadBike.Website.Controllers
{
    [Authorize(Roles = "user")]
    public class CartController : Controller
    {
        private readonly IBikeRepository  _bikeRepository;
        private readonly ShoppingCart _shoppingCart;

        public CartController(IBikeRepository bikeRepository, ShoppingCart shoppingCart)
        {
            _bikeRepository = bikeRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Route("Cart/AddToShoppingCart/{bikeId:int}")]
        public RedirectToActionResult AddToShoppingCart(int bikeId)
        {
            var selectedDrink = _bikeRepository.Get(bikeId);
            if (selectedDrink != null)
            {
                _shoppingCart.AddToCart(selectedDrink, 1);
            }
            return RedirectToAction("Index");
        }

        [Route("Cart/RemoveFromShoppingCart/{drinkId:int}")]
        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var selectedDrink = _bikeRepository.Get(drinkId);
            if (selectedDrink != null)
            {
                _shoppingCart.RemoveFromCart(selectedDrink);
            }
            return RedirectToAction("Index");
        }
    }
}