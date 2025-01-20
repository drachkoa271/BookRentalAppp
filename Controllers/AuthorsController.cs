using Microsoft.AspNetCore.Mvc;
using BookRentalApp.Models;
using BookRentalApp.Data;

namespace BookRentalApp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _repository;

        public AuthorsController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var authors = _repository.GetAll();
            return View(authors);
        }

        public IActionResult Details(int id)
        {
            var author = _repository.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid)
            {
                _repository.Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public IActionResult Edit(int id)
        {
            var author = _repository.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _repository.Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public IActionResult Delete(int id)
        {
            var author = _repository.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
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
