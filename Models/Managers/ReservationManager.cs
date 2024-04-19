﻿using System;
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
                    DatabaseManager databaseManager1 = new DatabaseManager();
                    newReservation.ReservationID = (databaseManager1.CountRowsReservation() +1).ToString();

                   
                    DatabaseManager databaseManager = new DatabaseManager();
                    databaseManager.AddToDatabse(newReservation);
                }
            
            
            
        }
        public List<Reservation> Getreservation(IUser user)
        {
            List<Reservation> list = new List<Reservation>();
            DatabaseManager dbManager = new DatabaseManager();
            list=dbManager.GetReservationFromDatabse(user);
            return list;
        }
    }
}
