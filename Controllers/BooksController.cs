﻿using Microsoft.AspNetCore.Mvc;
using BookRentalApp.Data;
using BookRentalApp.Models;

namespace BookRentalApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;
        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var books = _repository.GetAll();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public IActionResult Edit(int id)
        {
            var book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repository.Update(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public IActionResult Delete(int id)
        {
            var book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
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
