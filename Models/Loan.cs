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
            Instructor = null;
            this.DateBorrowed = DateBorrowed;
            this.DueDate = DueDate;
        }
        public Loan(string LoanId, Book book, Instructor instructor, DateTime DateBorrowed, DateTime DueDate, bool IsActive = true)
        {
            LoanID = LoanId;
            Book = book;
            this.Instructor = instructor;
            Student = null;
            this.DateBorrowed = DateBorrowed;
            this.DueDate = DueDate;
        }

    }
}
