using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    internal class Fine
    {
        //public const fineRate;

        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public decimal Amount { get; set; }
        public Loan Loan { get; set; }
        public bool IsActive { get; set; }
        public int DaysOverdue { get; set; }
        public string FineID { get; set; }

        public Fine() { }

        public Fine(Student student, Loan loan, bool IsActive)
        {
            this.Student = student;
            this.Loan = loan;
            this.IsActive = IsActive;

        }

        public Fine(Instructor instructor, Loan loan, bool IsActive)
        {
            this.Instructor = instructor;
            this.Loan = loan;
            this.IsActive = IsActive;

        }

    }
}
