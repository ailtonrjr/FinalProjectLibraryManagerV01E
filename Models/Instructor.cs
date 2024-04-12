using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    internal class Instructor
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string password { get; set; }
        public bool HasBorrowed { get; set; }
        public List<Book> BorroewdBooks { get; set; }
        public bool IsFined { get; set; }
        public int TotalFines { get; set; }

        public Instructor() { }

        public Instructor (string name, string iD, string password, bool hasBorrowed, List<Book> borroewdBooks, bool isFined, int totalFines)
        {
            this.Name = name;
            this.ID = iD;
            this.password = password;

        }
    }
}
