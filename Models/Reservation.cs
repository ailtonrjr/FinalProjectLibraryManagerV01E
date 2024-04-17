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
        public IUser User { get; set; }
        public Book Book { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime ReservationDueDate { get; set; }

        public Reservation() { }

        public Reservation(Book book, Student student, DateTime reservsationDate)
        {
            this.Book = book;
            this.Student = student;
            ReservationDueDate = reservsationDate;
        }

        public Reservation(Book book, Instructor instructor, DateTime reservsationDate,string reservationID)
        {
            
            this.Book = book;
            this.Instructor = instructor;
            ReservationDueDate = reservsationDate;
            this.ReservationID = reservationID;
        }

        public Reservation(Book book, IUser user, DateTime reservsationDate,string reservationID)
        {

            this.Book = book;
            this.User=user;
            ReservationDueDate = reservsationDate;
            this.ReservationID=reservationID;
        }

        public override string ToString()
        {
            return $"Rervation Id: {ReservationID},   Book: {this.Book.Title},   User: {this.User.Name},  Reservation Valid Till: {this.ReservationDueDate}";
        }
    }
}
