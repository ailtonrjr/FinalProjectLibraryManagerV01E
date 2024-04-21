using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    public class Fine
    {
        public string ID { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public IUser User { get; set; }
        public decimal Amount { get; set; }
        public Loan loan { get; set; }
        public bool IsActive { get; set; }
        public string UserID { get; internal set; }
        public string LoanID { get; internal set; }
        public string UserType { get; internal set; }
        public int FineAmount { get; internal set; }

        public Fine()
        {

        }

        public Fine(string iD, Student student, decimal amount, Loan loan)
        {
            ID = iD;
            Student = student;
            this.loan = loan;
            IsActive = true;
            Amount = CalculateFine();
        }
        public Fine(string iD, Instructor instructor, decimal amount, Loan loan)
        {
            ID = iD;
            Instructor = instructor;
            this.loan = loan;
            IsActive = true;
            Amount = CalculateFine();
        }

        public Fine(string iD, IUser user, decimal amount, Loan loan)
        {
            ID = iD;
            User = user;
            this.loan = loan;
            IsActive = true;
            Amount = CalculateFine();
        }

        public int CalculateFine()
        {
            DateTime today = DateTime.Today;

            DateTime dueDate = loan.DueDate;

            TimeSpan difference = today - dueDate;

            int daysOverdue = (int)difference.TotalDays;
            return 5 * daysOverdue;
        }
    }
}
