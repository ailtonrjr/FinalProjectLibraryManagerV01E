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

        //public bool isAvailable {get { return Book != null && Book.Copies > 0; }
        public string ISBN { get; set; }

        public Book() { }

        public Book(string title, string author,string Isbn,int copies,int rating,string location)
        {
            this.ISBN = ISBN;
            this.Title = title;
            this.Author = author;
            this.Rating = rating;
            this.Location = location;
            this.Copies= copies;
        }

        //public bool IsAvailable(Book book)
        //{
        //    bool isAvailable;

        //    if (book.Copies < 1)
        //    {
        //        isAvailable = false;
        //    }

        //    else
        //    {
        //        isAvailable = true;
        //    }

        //    this.isAvailable = isAvailable;
        //}

        public string ToDisplay()
        {
            return $" BookID: {BookID} , Title: {Title}, Author: {Author}";
        }

    }    
}
