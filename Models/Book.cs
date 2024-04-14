using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models
{
    public class Book
    {
        public string BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public int Copies { get; set; }
        public string Location { get; set; }
        public string ISBN { get; set; }

        public Book() { }

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }

        public string ToDisplay()
        {
            return $" {BookID} , {Title}, {Author}";
        }

    }    
}
