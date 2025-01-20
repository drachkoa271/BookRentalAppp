using Microsoft.AspNetCore.Mvc;
using BookRentalApp.Models;
using BookRentalApp.Data;
using Microsoft.Extensions.FileProviders;

namespace BookRentalApp.Controllers
{
    public class LoansController : Controller
    {
        private readonly ILoanRepository _repository;
        public LoansController(ILoanRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var loan = _repository.GetAll();
            return View(loan);
        }
        public IActionResult Details(int id)
        {
            var loan = _repository.GetById(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Loan loan)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(loan);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var loan = _repository.GetById(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Loan loan)
        {
            if (id != loan.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repository.Update(loan);
                return RedirectToAction(nameof(Index));
            }
            return View(loan);
        }
        public IActionResult Delete(int id)
        {
            var loan = _repository.GetById(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
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