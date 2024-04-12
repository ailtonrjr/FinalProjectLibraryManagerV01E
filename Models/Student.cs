using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    internal class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        public bool HasBorrowed{ get; set; }
        public List<Book> BorroewdBooks { get; set; }
        public bool IsFined { get; set; }
        public int TotalFines { get; set; }

        //Labriarian:Labrarian

        public Student() { }

        public Student(string name, string id, string password)
        {
            this.Name = name;
            this.ID = id;
            this.Password = password;
        }

    }
}
