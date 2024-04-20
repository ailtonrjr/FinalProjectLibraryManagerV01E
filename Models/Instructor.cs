using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    public class Instructor:IUser
    {
        public string Name { get; set; }
        public int ID { get; set; }
        string password;
        public bool IsStudent {  get; set; }
        public string Password { get { return password; } set { password = value; } }
        public List<Book> books { get; set; }
        public bool IsFined { get; set; }
        public bool HasBorrowed { get; set; }
        public int TotalFine { get; set; }

        public Instructor(string Name, int id, string password)
        {
            this.Name = Name;
            ID = id;
            this.password = password;
            IsStudent = false;

        }

    }
}
