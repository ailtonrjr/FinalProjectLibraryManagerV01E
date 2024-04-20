namespace FinalProjectLibraryManagerV01E.Models
{
    public class Reservation
    {
        public string ReservationID { get; set; }
        public IUser User { get; set; }
        public Book Book { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime DateReserved {  get; set; }
        public DateTime ReservationDueDate { get { return reservationDueDate; } set { reservationDueDate = value; } }
        DateTime reservationDueDate;
        public bool IsInstructor {  get; set; }

        
        public Reservation() { }

        public Reservation(Book book, Student student, DateTime reservsationDate)
        {
            this.Book = book;
            this.Student = student;
            DateReserved = reservsationDate;
            reservationDueDate = DateReserved.AddDays(7);
            IsInstructor = false;         


        }

        public Reservation(Book book, Instructor instructor, DateTime reservsationDate)
        {
            
            this.Book = book;
            this.Instructor = instructor;
            DateReserved = reservsationDate;
            ReservationDueDate = DateReserved.AddDays(10);
            IsInstructor = true;
             
        }

        public Reservation(Book book, IUser user, DateTime reservsationDate)
        {

            this.Book = book;
            this.User=user;
            DateReserved = reservsationDate;
            ReservationDueDate = DateReserved.AddDays(7);
            
        }

        public override string ToString()
        {
            return $"Reservation Id: {ReservationID},   Book: {Book.Title},   User: {this.User.Name},  Reservation Valid Till: {this.ReservationDueDate}";
        }
    }
}
