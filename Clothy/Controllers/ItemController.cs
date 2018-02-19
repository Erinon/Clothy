using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clothy.Models.ClothyViewModels;
using Clothy.Entities;
using Clothy.Repositories;
using Microsoft.AspNetCore.Identity;
using Clothy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clothy.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Preview(Guid itemId)
        {
            Item target = await _repository.GetItemById(itemId);

            ItemViewModel model = new ItemViewModel()
            {
                Id = target.Id,
                Name = target.Name,
                Price = target.Price,
                Description = target.Description,
                Sizes = target.Sizes,
                Picture = target.Picture,
                CategoryId = target.CategoryId
            };

            return View(model);
        }

        public async Task<IActionResult> Categorize(Guid catId)
        {
            ListItemViewModel model = new ListItemViewModel(
                (await _repository.GetItemsByCategoryId(catId))
                .Select(i => new ItemViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Description = i.Description,
                    Sizes = i.Sizes,
                    Picture = i.Picture,
                    CategoryId = i.CategoryId,
                    IsAdmin = false
                }).ToList());

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            ListItemViewModel model = new ListItemViewModel(
                (await _repository.GetAllItems())
                .Select(i => new ItemViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Description = i.Description,
                    Sizes = i.Sizes,
                    Picture = i.Picture,
                    CategoryId = i.CategoryId,
                    IsAdmin = true
                }).ToList());

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid itemId)
        {
            Item target = await _repository.GetItemById(itemId);

            AddItemViewModel model = new AddItemViewModel()
            {
                Id = target.Id,
                Name = target.Name,
                Price = target.Price,
                Description = target.Description,
                Sizes = target.Sizes,
                Picture = target.Picture,
                CategoryId = target.CategoryId
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(AddItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            Item target = new Item
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Sizes = model.Sizes,
                Picture = model.Picture,
                CategoryId = model.CategoryId
            };

            await _repository.EditItem(target);

            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(Guid itemId)
        {
            await _repository.RemoveItem(itemId);

            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            Item target = new Item(
                model.Name,
                model.Price,
                model.Description,
                model.Sizes,
                model.Picture,
                model.CategoryId);

            await _repository.AddItem(target);

            return RedirectToAction("Manage");
        }
    }
}