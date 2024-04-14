using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Password = "root",
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
                    string sql = "INSERT INTO fine(StudentID,Password,Name,HasBorrowed,Isfined) VALUES('" + student.ID + "','" + student.Password + "','" + student.Name + "','" + student.HasBorrwed + "','" + student.IsFined + "');";
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
    }
}
