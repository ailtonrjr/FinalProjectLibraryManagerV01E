using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models.Managers
{
    internal class LoanManager
    {
        private List<Loan> loans = new List<Loan>();

        public void AddLoan(Loan loan)
        {
            loans.Add(loan);
        }

        public List<Loan> GetAllLoans()
        {
            return loans;
        }

        public List<Loan> GetLoansByStudent(Student student)
        {
            return loans.FindAll(loan => loan.Student == student);
        }

        public void RemoveLoan(Loan loan)
        {
            loans.Remove(loan);
        }
        public List<Loan> GetLoanFromDatabase(IUser user)
        {
            List<Loan> loans = new List<Loan>();
            DatabaseManager databaseManager= new DatabaseManager();
            loans=databaseManager.GetLoanFromDatabase(user);
            return loans;
        }
    }
}
