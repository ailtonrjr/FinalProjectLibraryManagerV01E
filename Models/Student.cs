using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        string password;
        public string Password { get { return password; } }
        public List<Book> books { get; set; }
        public bool IsFined { get; set; }
        public bool HasBorrwed { get; set; }
        public int TotalFine { get; set; }

        public Student() { }

        public Student(string Name, int id)
        {
            this.Name = Name;
            ID = id;
            //this.password = password;
            IsFined = false;
            TotalFine = 0;
            HasBorrwed = false;

        }


    }
}
