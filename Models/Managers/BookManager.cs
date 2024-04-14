using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibraryManagerV01E.Models.Managers
{
    public static class BookManager
    {
        public static List<Book> books = new List<Book>()
        {
            new Book{Title = "Paradise", Author = "Joseph Brown", ISBN = "Terror"},
            new Book{Title = "Hello", Author = "Joane Yellow", ISBN = "Fantasy"},
            new Book{Title = "Yaya", Author = "Nini Nunu", ISBN = "History"},
            new Book{Title = "Tomorrowland", Author = "Myself", ISBN = "Comedy"},
        };



        
        //public static AddBook(Book book)
        //{
        //    books.Add(book);
        //}

        public static List<Book> GetAllBooks()
        {
            return books;
        }

        public static Book GetBookByTitle(string title)
        {
            return books.Find(book => book.Title == title);
        }

        public static List<Book> SearchForBooks(string filterText)
        {
            var booksFound = books.Where(x => !string.IsNullOrWhiteSpace(x.Title) &&
                            x.Title
                       .StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (booksFound == null || booksFound.Count == 0)
            {
                booksFound = books.Where(x => !string.IsNullOrWhiteSpace(x.Author) && x.Author
                .StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }

            if (booksFound == null || booksFound.Count == 0)
            {
                booksFound = books.Where(x => !string.IsNullOrWhiteSpace(x.ISBN) && x.ISBN
                .StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }

            else
            {
                return booksFound;
            }
            return booksFound;
        }

        public static List<Book>SearchBooksCombined (string title, string author)
        {
            List<Book> foundBooks = new List<Book>();
            foreach (var book in books)
            {
                if (book.Title == title && book.Author == author)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        public static void UpdateBook (string bookTitle, Book updatedBook)
        {
            var index = books.FindIndex(book => book.Title == updatedBook.Title);
            if (index != -1)
            {
                books[index] = updatedBook;
            }
        }

        //public static List<Book> SearchBooksTitleOrAuthor (string insertedInfo)
        //{
        //    var booksFound = books.Where(x => !string.IsNullOrWhiteSpace(x.Title) &&
        //                    x.Title
        //               .StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

        //    if (booksFound == null || booksFound.Count == 0)
        //    {
        //        booksFound = books.Where(x => !string.IsNullOrWhiteSpace(x.Author) && x.Author
        //        .StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
        //    }

        //    if (booksFound == null || booksFound.Count == 0)
        //    {
        //        booksFound = books.Where(x => !string.IsNullOrWhiteSpace(x.ISBN) && x.ISBN
        //        .StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
        //    }

        //    else
        //    {
        //        return booksFound;
        //    }
        //    return booksFound;
        //}

        //public static void RemoveBook (string bookTitle)
        //{
        //    books.Remove(book);
        //}        
    }
}
