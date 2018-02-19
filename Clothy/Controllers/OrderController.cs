using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Clothy.Repositories;
using Clothy.Models.ClothyViewModels;
using Clothy.Entities;
using Microsoft.AspNetCore.Identity;
using Clothy.Models;

namespace Clothy.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(
            IOrderRepository repository, 
            UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult MakeOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrder(MakeOrderViewModel model)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (!ModelState.IsValid)
            {
                return View("MakeOrder", model);
            }

            Order target = new Order(
                currentUser.Id,
                model.Mail,
                model.Phone,
                model.Address);

            await _repository.MakeOrder(target);

            return View("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ShowOrders()
        {
            OrderListViewModel model = new OrderListViewModel(
                (await _repository.GetAllOrders())
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Mail = o.Mail,
                    Phone = o.Phone,
                    Address = o.Address,
                    DateCreated = o.DateCreated
                }).ToList());

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}