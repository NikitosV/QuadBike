using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.AccountViewModels;

namespace QuadBike.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagerService _userManagerService;

        public AccountController(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        public IActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            var userId = _userManagerService.GetUserByName(currentUserName);
            return View(_userManagerService.ShowUserInfoById(userId.Result.Id));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)                   // Register
        {
            if (ModelState.IsValid)
            {
                var result =  await _userManagerService.CreateAccount(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)                                        // Login In
        {
            if (ModelState.IsValid)
            {
                var result = await _userManagerService.LogInAccount(model);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Not correct login/password!");
                    //return View("Error", new string[] { "Not correct login/password!" });
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()                                                    //Log Out
        {
            // удаляем аутентификационные куки
            await _userManagerService.LogOffAccount();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var res = await _userManagerService.GetUserById(id);

            if (res == null)
            {
                return NotFound();
            }
            EditAccountUserViewModel model = new EditAccountUserViewModel {
                Id = res.Id,
                Name = res.Name,
                PhoneNumber = res.PhoneNumber,
                Adress = res.Adress,
                Description = res.Description
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAccountUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = await _userManagerService.GetUserById(model.Id);
                if (account != null)
                {
                    account.Name = model.Name;
                    account.PhoneNumber = model.PhoneNumber;
                    account.Adress = model.Adress;
                    account.Description = model.Description;

                    var result = await _userManagerService.UpdateAccount(account);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }
    }
}