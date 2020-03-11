using ASPNET.Models;
using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASPNET.Controllers
{
    public class CategoryManualController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        // GET: CategoryManual

        public CategoryManualController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await categoryRepository.GetAllAsync();

            var result = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                result.Add(new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            return View(result);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id, Name")] Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            var result = await categoryRepository.SaveAsync(category);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Create");

            var category = await categoryRepository.GetByIdAsync(id.Value);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Name")] Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            var result = await categoryRepository.SaveAsync(category);
            return RedirectToAction("Index");
        }
    }
}