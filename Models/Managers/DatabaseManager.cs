using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.VisualBasic;
using MySqlConnector;

namespace FinalProjectLibraryManagerV01E.Models.Managers
{
    public class DatabaseManager
    {
        string connectionString;
        public DatabaseManager()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "Dudato1312*",
                Database = "library"
            };
            connectionString = builder.ConnectionString;
        }

        //This method is used to add newly created objects in the database
        public void AddToDatabse(object obj)
        {
            if (obj is Book)
            {
                Book book = (Book)obj;
                using (var conn = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO books(Title,Author,ISBN,Rating,Copies,Location) VALUES('" + book.Title + "','" + book.Author + "','" + book.ISBN + "','" + book.Rating + "','" + book.Copies + "','" + book.Location + "');";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            else if (obj is Loan)
            {
                Loan loan = (Loan)obj;
                AddToBridgingEntities(loan);
                using (var conn = new MySqlConnection(connectionString))
                {
                    string sql = "";
                    if (loan.Student == null)
                    {
                        sql = "INSERT INTO loan(LoanID,BookID,UserID,UserName,UserType,IsActive,DateBorrowed,DateDue) VALUES('" + loan.LoanID + "','" + loan.Book.ISBN + "','" + loan.Instructor.ID + "','" + loan.Instructor.Name + "','" + "Instructor" + "','" + loan.IsActive + "','" + loan.DateBorrowed + "','" + loan.DueDate + "');";

                    }
                    else
                    {
                        sql = "INSERT INTO loan(LoanID,BookID,UserID,UserName,UserType,IsActive,DateBorrowed,DateDue) VALUES('" + loan.LoanID + "','" + loan.Book.ISBN + "','" + loan.Student.ID + "','" + loan.Student.Name + "','" + "Student" + "','" + loan.IsActive + "','" + loan.DateBorrowed + "','" + loan.DueDate + "');";

                    }
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }

            }
            else if (obj is Fine)
            {
                Fine fine = (Fine)obj;
                using (var conn = new MySqlConnection(connectionString))
                {
                    string sql = "";
                    if (fine.Student == null)
                    {
                        sql = "INSERT INTO fine(FineID,UserID,LoanID,UserType,IsActive,FineAmount) VALUES('" + fine.ID + "','" + fine.Instructor.ID + "','" + fine.loan.LoanID + "','" + "Instructor" + "','" + fine.IsActive + "','" + fine.Amount + "');";

                    }
                    else
                    {
                        sql = "INSERT INTO fine(FineID,UserID,LoanID,UserType,IsActive,FineAmount) VALUES('" + fine.ID + "','" + fine.Student.ID + "','" + fine.loan.LoanID + "','" + "Student" + "','" + fine.IsActive + "','" + fine.Amount + "');";

                    }
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            else if (obj is Student)
            {
                Student student = (Student)obj;
                using (var conn = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO fine(StudentID,Password,Name,HasBorrowed,Isfined) VALUES('" + student.ID + "','" + student.Password + "','" + student.Name + "','" + student.HasBorrowed + "','" + student.IsFined + "');";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            else if (obj is Instructor)
            {
                Instructor instructor = (Instructor)obj;
                using (var conn = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO fine(StudentID,Password,Name,HasBorrowed,Isfined) VALUES('" + instructor.ID + "','" + instructor.Password + "','" + instructor.Name + "','" + instructor.HasBorrowed + "','" + instructor.IsFined + "');";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            else if (obj is Librarian)
            {
                Librarian librarian = (Librarian)obj;
                using (var conn = new MySqlConnection(connectionString))
                {
                    string sql = "INSERT INTO fine(EmployeeID,Password,Name) VALUES('" + librarian.ID + "','" + librarian.Password + "','" + librarian.Name + "');";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //This method is executed whenever a user borrows a book
        //It inserts the data to StudentBooks and InstructorBooks, depending on the type of user

        public void AddToBridgingEntities(Loan loan)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                string sql = "";
                if (loan.Instructor == null)
                {
                    sql = "INSERT INTO studentbook(BookID,StudentID,StudentName,BookTitle) VALUES('" + loan.Book.ISBN + "','" + loan.Student.ID + "','" + loan.Student.Name + "','" + loan.Book.Title + "');";
                }
                else
                {
                    sql = "INSERT INTO instructorbook(BookID,InstructorID,InstructorName,BookTitle) VALUES('" + loan.Book.ISBN + "','" + loan.Instructor.ID + "','" + loan.Instructor.Name + "','" + loan.Book.Title + "');";

                }
                MySqlCommand command = new MySqlCommand(sql, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public IUser VerifyLogin(int ID,string password)
        {
            string name="";
            bool Hasborrowed;
            bool IsFined;
            using (var conn = new MySqlConnection(connectionString))
            {
                List<Book> books;
                conn.Open();
                string sql = "(Select StudentName,HasBorrowed,IsFined from student where StudentID='"+ID.ToString()+ "' AND Password='"+password+"');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                if (reader == null)
                {
                     sql = "(Select InstructorName,HasBorrowed,IsFined from instructor where InstructorID='" + ID.ToString() + "' AND Password='" + password + "');";
                     command = new MySqlCommand(sql, conn);
                     reader=command.ExecuteReader();
                    if (reader == null)
                    {
                        return null ;
                    }
                    else
                    {
                        while (reader.Read())
                        {                            
                            name = reader.GetString(0);
                            Hasborrowed=reader.GetBoolean(1);
                            IsFined = reader.GetBoolean(2);
                        }
                        Instructor instructor = new Instructor(name,ID,password);
                        return instructor;

                    }

                }
                else
                {
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                        Hasborrowed = reader.GetBoolean(1);
                        IsFined = reader.GetBoolean(2);
                    }
                    Student student = new Student(name,ID,password);
                    return student;
                }
                




            }
        }

        public List<Reservation> GetReservationFromDatabse(IUser user)
        {
            string BookId;
            DateTime DT;
            bool IsActive;
            string reservationID;
            List<Reservation> reservations = new List<Reservation>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "(Select BookID,IsActive,DateDue,ReservationId from reservation where userID='" + user.ID+ "');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BookId=reader.GetString(0);
                    
                    if (reader.GetString(1) == "1")
                    {
                        IsActive = true;
                    }
                    else
                    {
                        IsActive = false;
                    }
                    DT= reader.GetDateTime(2);
                    reservationID=reader.GetString(3);
                    Book book = GetBookFromDatabase(BookId);
                    Reservation reservation = new Reservation(book,user,DT,reservationID);
                    reservations.Add(reservation);
                }
                return reservations;
            }
        }
        public Book GetBookFromDatabase(string bookID)
        {
            string author="";
            string Booktitle="";
            int copies=0;
            int Rating=0;
            string location = "";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "(Select Author,Title,Copies,Rating,Location from books where ISBN='" + bookID + "');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    author = reader.GetString(0);
                    Booktitle = reader.GetString(1);
                    copies=reader.GetInt32(2);
                    Rating = reader.GetInt32(3);
                    location=reader.GetString(4);

                }
                Book book = new Book(author, Booktitle, bookID, copies, Rating, location);
                return book;
            }
        }
        //public Loan GetLoanFromDatabase(int LoanID)
        //{
        //    using (var conn = new MySqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        string sql = "(Select Use,BookTitle,Copies,Rating,Location from book where BookID='" + bookID + "');";
        //        MySqlCommand command = new MySqlCommand(sql, conn);
        //        var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            author = reader.GetString(0);
        //            Booktitle = reader.GetString(1);
        //            copies = reader.GetInt32(2);
        //            Rating = reader.GetInt32(3);
        //            location = reader.GetString(4);

        //        }
        //    }
        //}
    }
}
