using System.Collections.Generic;
using System.Linq;
using BookRentalApp.Models;

namespace BookRentalApp.Data
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;
        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Loan> GetAll()
        {
            return _context.Loans.ToList();
        }
        public Loan GetById(int id)
        {
            return _context.Loans.Find(id);
        }
        public void Add(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }
        public void Update(Loan loan)
        {
            _context.Loans.Remove(loan);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var loan = _context.Loans.Find(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
        }
    }
}
