using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context.CommitProvider;
using QuadBike.Model.ViewModel.ModerViewModels;

namespace QuadBike.Website.Controllers
{
    [Authorize(Roles = "moderator")]
    public class ModerController : Controller
    {
        private readonly IUserManagerService _userManagerService;
        private readonly ICommitProvider _commitProvider;

        public ModerController(IUserManagerService userManagerService, ICommitProvider commitProvider)
        {
            _userManagerService = userManagerService;
            _commitProvider = commitProvider;
        }

        public IActionResult Index()
        {
            return View(_userManagerService.ShowListOfRoles());
        }

        public IActionResult UserList()
        {
            return View(_userManagerService.ShowListUsers());
        }

        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            var account = _userManagerService.GetUserById(userId);
            if (account != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManagerService.GetRolesByAccount(userId);
                var allRoles = _userManagerService.ShowListOfRoles();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = account.Result.Id,
                    UserEmail = account.Result.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var account = _userManagerService.FindByIdRole(userId);

            if (account != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManagerService.GetRolesByAccount(userId);
                // получаем все роли
                var allRoles = _userManagerService.ShowListOfRoles();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManagerService.AddToRole(userId, addedRoles);

                await _userManagerService.RemovedFromRoles(userId, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(string userId)
        {
            var account = await _userManagerService.GetUserById(userId);
            if (account != null)
            {
                IdentityResult result = await _userManagerService.DeleteAccount(account);
                _commitProvider.Save();
            }
            return RedirectToAction("UserList");
        }
    }
}