﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.OrderViewModels;

namespace QuadBike.Website.Controllers
{
    [Authorize(Roles = "user")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserManagerService _userManagerService;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, IUserManagerService userManagerService)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _userManagerService = userManagerService;
        }

        public IActionResult Buy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);
            var res = _orderRepository.OrdersForCurrentProvider(userId.Result.Id);
            return View(res);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some bikes first");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order, currentUserName);
                _shoppingCart.ClearCart();
                return RedirectToAction("Buy");
            }

            return View(order);
        }
    }
}