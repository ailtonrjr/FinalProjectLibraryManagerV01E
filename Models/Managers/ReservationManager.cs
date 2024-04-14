using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models.Managers
{
    public class ReservationManager
    {
        public ReservationManager() { }

        public List<Reservation> reservations = new List<Reservation>(); 

        public void AddReservation(Reservation newReservation)
        {
            if (newReservation != null)
            {
                var MaxID = reservations.Max(x => x.ReservationID);
                newReservation.ReservationID = MaxID + 1;
                reservations.Add(newReservation);
            }
        }
    }
}
