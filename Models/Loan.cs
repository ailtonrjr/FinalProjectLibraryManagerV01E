using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    public class Loan
    {
        public string LoanID { get; set; }
        public IUser User { get; set; }
        public Book Book { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime DateBorrowed { get; set; }
        public bool IsActive { get; set; }
        public DateTime DueDate { get; set; }
        public Loan(string LoanId, Book book, Student student, DateTime DateBorrowed, DateTime DueDate, bool IsActive = true)
        {
            LoanID = LoanId;
            Book = book;
            Student = student;
            this.DateBorrowed = DateBorrowed;
            this.DueDate = DateBorrowed.AddDays(7);
        }
        public Loan(string LoanId, Book book, Instructor instructor, DateTime DateBorrowed, DateTime DueDate, bool IsActive = true)
        {
            LoanID = LoanId;
            Book = book;
            this.Instructor = instructor;
            this.DateBorrowed = DateBorrowed;
            this.DueDate = DateBorrowed.AddDays(10);
        }
        public Loan(string LoanId, Book book, IUser user, DateTime DateBorrowed, DateTime DueDate, bool IsActive = true)
        {
            LoanID = LoanId;
            Book = book;
            this.User = user;
            this.DateBorrowed = DateBorrowed;
            if (user.IsStudent == true)
            {
                this.DueDate = DateBorrowed.AddDays(7);

            }
            else
            {
                this.DueDate = DateBorrowed.AddDays(10);
            }

        }
        public Loan() { }

        public override string ToString()
        {
            return $"Loan ID: {LoanID}, Book Name: {Book.Title}, User Name: {User.Name},  Date borrowed: {DateBorrowed}, DateDue: {DueDate}";
        }


    }
}
