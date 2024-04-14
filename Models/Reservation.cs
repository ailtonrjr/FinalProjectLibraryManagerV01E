using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public Book Book { get; set; }
        public Student Student { get; set; }
        public DateTime ReservationData { get; set; }
        public DateTime ExpirationData { get; set; }

        //decrease the copy of the book
    }
}
