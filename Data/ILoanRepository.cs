using System.Collections.Generic;
using BookRentalApp.Models;

namespace BookRentalApp.Data
{
    public interface ILoanRepository
    {
        IEnumerable<Loan> GetAll();
        Loan GetById (int id);
        void Add (Loan loan);
        void Update (Loan loan);
        void Delete (int id);
    }
}
