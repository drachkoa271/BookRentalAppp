﻿using System.Collections.Generic;
using System.Linq;
using BookRentalApp.Models;

namespace BookRentalApp.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }
        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
