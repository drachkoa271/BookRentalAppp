using Microsoft.AspNetCore.Mvc;
using BookRentalApp.Models;
using BookRentalApp.Data;

namespace BookRentalApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Indedx()
        {
            var users = _repository.GetAll();
            return View(users);
        }
        public IActionResult Details(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        public IActionResult Edit(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repository.Update(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
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
