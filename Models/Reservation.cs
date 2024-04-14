using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    public class Reservation
    {
        public string ReservationID { get; set; }
        public Book Book { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime ReservsationDate { get; set; }

        public Reservation(string iD, Book book, Student student, DateTime reservsationDate)
        {
            ReservationID = iD;
            this.Book = book;
            this.Student = student;
            ReservsationDate = reservsationDate;
        }

        public Reservation(string iD, Book book, Instructor instructor, DateTime reservsationDate)
        {
            ReservationID = iD;
            this.Book = book;
            this.Instructor = instructor;
            ReservsationDate = reservsationDate;
        }
    }
}
