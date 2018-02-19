using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clothy.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Clothy.Models;
using Clothy.Models.ClothyViewModels;

namespace Clothy.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(
            IUserRepository repository, 
            UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Preview()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            CartViewModel model = new CartViewModel(
                (await _repository.GetItemsFromCart(currentUser.Id))
                .Select(i => new CartItemViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price
                }).ToList());

            return View(model);
        }

        public async Task<IActionResult> RemoveFromCart(Guid itemId)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            await _repository.RemoveFromCart(currentUser.Id, itemId);

            return RedirectToAction("Preview");
        }

        public async Task<IActionResult> AddToCart(Guid itemId)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            await _repository.AddToCart(currentUser.Id, itemId);

            return RedirectToAction("Preview");
        }
    }
}
