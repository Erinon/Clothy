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
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid catId)
        {
            Category target = await _repository.GetCategoryById(catId);

            AddCategoryViewModel model = new AddCategoryViewModel()
            {
                Id = target.Id,
                Name = target.Name,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            Category target = new Category
            {
                Id = model.Id,
                Name = model.Name,
            };

            await _repository.EditCategory(target);

            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            CategoryListViewModel model = new CategoryListViewModel(
                (await _repository.GetAllCategories())
                .Select(i => new CategoryViewModel()
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToList());

            return View(model);
        }

        public async Task<IActionResult> Remove(Guid catId)
        {
            await _repository.RemoveCategory(catId);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            Category target = new Category(model.Name);

            await _repository.AddCategory(target);

            return RedirectToAction("Manage");
        }
    }
}