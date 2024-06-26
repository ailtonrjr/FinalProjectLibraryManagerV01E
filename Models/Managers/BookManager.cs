﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;

namespace FinalProjectLibraryManagerV01E.Models.Managers
{
    public  class BookManager
    {
        public static List<Book> books = new List<Book>()
        {
            new Book{Title = "Paradise", Author = "Joseph Brown", ISBN = "Terror"},
            new Book{Title = "Hello", Author = "Joane Yellow", ISBN = "Fantasy"},
            new Book{Title = "Yaya", Author = "Nini Nunu", ISBN = "History"},
            new Book{Title = "Tomorrowland", Author = "Myself", ISBN = "Comedy"},
        };

        public static void AddBook(Book newBook)
        {
            if (newBook != null)
            {
                var MaxID = books.Max(x => x.BookID);
                newBook.BookID = MaxID + 1;
                books.Add(newBook);
            }
        }

        public static List<Book> GetAllBooks()
        {
            return books;
        }

        public static Book GetBookByTitle(string title)
        {
            return books.Find(book => book.Title == title);
        }

        public static List<Book> SearchBooksByTitleFull(string filterText)
        {
            var booksFound = books.Where(x => !string.IsNullOrWhiteSpace(x.Title) &&
                            x.Title.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (booksFound == null || booksFound.Count == 0)
            {
                return null;
            }

            return booksFound;
        }

        public static List<Book>SearchBooksByAuthorFull(string filterText)
        {
            var booksFound = books.Where(x => !string.IsNullOrWhiteSpace(x.Author) &&
                            x.Author.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (booksFound == null || booksFound.Count == 0)
            {
                return null;
            }

            return booksFound;
        }

        public static List<Book> SearchBooksByAuthor(string author)
        {
            //insert a RadioButton on the page the differentiate the methods invoked
            List<Book> foundBooks = new List<Book>();
            foreach (var book in books)
            {
                if (book.Author == author)
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
        //
        public static void DeleteBookd(string bookID)
        {
            var bookToDelete = books.FirstOrDefault(x => x.BookID == bookID);

            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
            }
        }

        public List<Book> SearchBookByTitle(string title)
        {
            List<Book> FoundBook = new List<Book>();
            DatabaseManager databaseManager = new DatabaseManager();
            FoundBook=databaseManager.GetBookFromDatabaseByTitle(title);
            return FoundBook;
        }

        public List<Book> SearchBookByAuthor(string Author)
        {
            List<Book> FoundBook = new List<Book>();
            DatabaseManager databaseManager = new DatabaseManager();
            FoundBook = databaseManager.GetBookFromDatabaseByAuthor(Author);
            return FoundBook;
        }

        public List<Book> SearchBookByFullTitle(string title)
        {
            List<Book> books = new List<Book>();
            DatabaseManager databaseManager=new DatabaseManager();
            books = databaseManager.GetBookFromDatabaseByFullTitle(title);
            return books;
        }

        public void ChangeRating(float NewRating,Book book)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            float NewAverageRating= book.CalculateAverageRating(NewRating);
            book.Rating= NewAverageRating;
            databaseManager.UpdateBookRatingInDatabase(book);
        }

        public float GetRating(string Id)
        {
            DatabaseManager databaseManager =new DatabaseManager();
            float NewRating=databaseManager.GetUpdatedRating(Id);
            return NewRating;
        }
    }
}
