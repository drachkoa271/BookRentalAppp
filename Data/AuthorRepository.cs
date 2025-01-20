using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using BookRentalApp.Models;

namespace BookRentalApp.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }
        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
        }
        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public void Update(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
