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
        public Book book { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public decimal Amount { get; set; }
        public Loan loan { get; set; }
        public bool IsActive { get; set; }
        public int DaysOverdue { get; set; }
        public Fine(string iD, Book book, Student student, decimal amount, Loan loan, bool isActive, int daysOverdue)
        {
            ID = iD;
            this.book = book;
            Student = student;
            Instructor = null;
            this.loan = loan;
            IsActive = true;
            DaysOverdue = 1;
            Amount = CalculateFine(DaysOverdue);
        }
        public Fine(string iD, Book book, Instructor instructor, decimal amount, Loan loan, bool isActive, int daysOverdue)
        {
            ID = iD;
            this.book = book;
            Instructor = instructor;
            Student = null;
            this.loan = loan;
            IsActive = true;
            DaysOverdue = 1;
            Amount = CalculateFine(DaysOverdue);
        }
        public int CalculateFine(int DaysOverdue)
        {
            return 5 * DaysOverdue;
        }
    }
}
