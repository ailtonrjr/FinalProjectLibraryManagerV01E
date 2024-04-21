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
        public float Rating { get; set; }
        public int Copies { get; set; }
        public string Location { get; set; }

        public List<float> EveryRating = new List<float>(); 
        //public bool isAvailable {get { return Book != null && Book.Copies > 0; }
        public string ISBN { get; set; }

        public Book() { }

        public Book(string title, string author,string Isbn,int copies,float rating,string location)
        {
            this.ISBN = Isbn;
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

        public float CalculateAverageRating(float NewRating)
        {
            float sum=0.0f;
            int count = 0;
            EveryRating.Add(NewRating);
            foreach(float rating in EveryRating)
            {
                sum += rating;
                count++;
            }
            float AverageRating = sum / count;
            return AverageRating;


        }
        public string ToDisplay()
        {
            return $" BookID: {ISBN} , Title: {Title}, Author: {Author}";
        }

    }    
}
