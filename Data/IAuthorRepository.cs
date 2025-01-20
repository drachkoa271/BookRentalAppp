using System.Collections.Generic;
using BookRentalApp.Models;

namespace BookRentalApp.Data
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(int id);
    }
}
