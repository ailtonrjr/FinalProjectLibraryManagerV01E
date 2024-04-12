using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    internal class Loan
    {
        public Book Book { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsActive { get; set; }
        public string LoanID { get; set; }


        public Loan() { }

        public Loan (Book book, Student student, DateTime dateBorrowed, DateTime dueDate)
        {
            this.Book = book;
            this.Student = student;
            this.DateBorrowed = dateBorrowed;
            this.DueDate = dueDate;
        }

        public Loan(Book book, Instructor instructor, DateTime dateBorrowed, DateTime dueDate)
        {
            this.Book = book;
            this.Instructor = instructor;
            this.DateBorrowed = dateBorrowed;
            this.DueDate = dueDate;
        }

    }    
}
