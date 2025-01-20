using Microsoft.AspNetCore.Mvc;
using BookRentalApp.Models;
using BookRentalApp.Data;

namespace BookRentalApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var categories = _repository.GetAll();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = _repository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _repository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _repository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
