using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    public class Student:IUser
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool IsStudent {  get; set; }
        string password;
        public string Password { get { return password; } set { password = value; } }
        public List<Book> books { get; set; }
        public bool IsFined { get; set; }
        public int TotalFine { get; set; }
        public bool HasBorrowed { get; set; }

        public Student() { }

        public Student(string Name, int id,string password)
        {
            this.Name = Name;
            ID = id;
            this.password = password;
            IsStudent = true;

        }


    }
}
