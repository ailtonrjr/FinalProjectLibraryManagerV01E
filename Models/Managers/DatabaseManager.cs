using MySqlConnector;
using Microsoft.Maui.Controls;
using System;

namespace FinalProjectLibraryManagerV01E.Models.Managers
{
    public class DatabaseManager
    {
        private bool isInstructor = false;
        public bool IsInstructor { get { return isInstructor; } }
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
            else if (obj is Reservation)
            {
                string usertype;
                Reservation reservation = (Reservation)obj;

                if (IsInstructor == true)
                {
                    usertype = "Instructor";
                }
                else
                {
                    usertype = "Student";
                }
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "";
                    if (usertype == "Student")
                    {
                        sql = "INSERT INTO reservation(ReservationID,BookId,UserType,UserId,IsActive,DateReserved,DateDue) VALUES('" + reservation.ReservationID + "','" + reservation.Book.ISBN + "','" + usertype + "','" + reservation.Student.ID + "','" + 1 + "','" + reservation.DateReserved.ToString("yyyy-MM-dd HH:mm:ss") + "','" + reservation.DateReserved.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss") + "');";

                    }
                    else if (usertype == "Instructor")
                    {
                        sql = "INSERT INTO reservation(ReservationID,BookId,UserType,UserId,IsActive,DateReserved,DateDue) VALUES('" + reservation.ReservationID + "','" + reservation.Book.ISBN + "','" + usertype + "','" + reservation.Instructor.ID + "','" + 1 + "','" + reservation.DateReserved.ToString("yyyy-MM-dd HH:mm:ss") + "','" + reservation.DateReserved.AddDays(10).ToString("yyyy-MM-dd HH:mm:ss") + "');";

                    }
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.ExecuteNonQuery();
                    var transaction = conn.BeginTransaction();
                    transaction.Commit();
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

        public IUser VerifyLogin(int ID, string password)
        {

            string name = "";
            bool Hasborrowed;
            bool IsFined;
            using (var conn = new MySqlConnection(connectionString))
            {
                List<Book> books;
                conn.Open();
                string sql = "(Select Name,HasBorrowed,IsFined from student where StudentID='" + ID.ToString() + "' AND Password='" + password + "');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                if (reader == null)
                {
                    isInstructor = true;
                    sql = "(Select InstructorName,HasBorrowed,IsFined from instructor where InstructorID='" + ID.ToString() + "' AND Password='" + password + "');";
                    command = new MySqlCommand(sql, conn);
                    reader = command.ExecuteReader();
                    if (reader == null)
                    {
                        return null;
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            name = reader.GetString(0);
                            Hasborrowed = reader.GetBoolean(1);
                            IsFined = reader.GetBoolean(2);
                        }
                        Instructor instructor = new Instructor(name, ID, password);
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
                    Student student = new Student(name, ID, password);
                    isInstructor = false;
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
                string sql = "(Select BookID,IsActive,DateReserved,ReservationId from reservation where userID='" + user.ID + "');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BookId = reader.GetString(0);

                    if (reader.GetString(1) == "1")
                    {
                        IsActive = true;
                    }
                    else
                    {
                        IsActive = false;
                    }
                    DT = reader.GetDateTime(2);
                    reservationID = reader.GetString(3);
                    Book book = GetBookFromDatabase(BookId);
                    Reservation reservation = new Reservation(book, user, DT);
                    reservation.ReservationID = reservationID;
                    reservations.Add(reservation);
                }
                return reservations;
            }
        }
        public Book GetBookFromDatabase(string bookID)
        {
            string author = "";
            string Booktitle = "";
            int copies = 0;
            int Rating = 0;
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
                    copies = reader.GetInt32(2);
                    Rating = reader.GetInt32(3);
                    location = reader.GetString(4);

                }
                Book book = new Book(Booktitle, author, bookID, copies, Rating, location);
                return book;
            }
        }

        public List<Book> GetBookFromDatabaseByFullTitle(string Title)
        {
            List<Book> books = new List<Book>();
            string author = "";
            string Id = "";
            int copies = 0;
            int Rating = 0;
            string location = "";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "(Select ISBN,Author,Copies,Rating,Location from books where Lower(Title)='" + Title.ToLower() + "');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Id = reader.GetString(0);
                    author = reader.GetString(1);
                    copies = reader.GetInt32(2);
                    Rating = reader.GetInt32(3);
                    location = reader.GetString(4);
                    Book book = new Book(Title, author, Id, copies, Rating, location);
                    books.Add(book);

                }
                return books;
            }
        }



        public List<Book> GetBookFromDatabaseByTitle(string Title)
        {
            List<Models.Book> FoundBooks = new List<Models.Book>();
            string author = "";
            string Id = "";
            int copies = 0;
            int Rating = 0;
            string location = "";
            string title = "";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "(Select ISBN,Title,Author,Copies,Rating,Location from books where Lower(Title) Like'" + Title + "%');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Id = reader.GetString(0);
                    title = reader.GetString(1);
                    author = reader.GetString(2);
                    copies = reader.GetInt32(3);
                    Rating = reader.GetInt32(4);
                    location = reader.GetString(5);
                    Book book = new Book(title, author, Id, copies, Rating, location);
                    FoundBooks.Add(book);

                }
                return FoundBooks;
            }
        }

        public List<Book> GetBookFromDatabaseByAuthor(string Author)
        {
            List<Models.Book> FoundBooks = new List<Models.Book>();
            string title = "";
            string Id = "";
            int copies = 0;
            int Rating = 0;
            string location = "";
            string author = "";
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "(Select ISBN,Title,Copies,Rating,Location,Author from books where Lower(Author) Like '" + Author.ToLower() + "%');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Id = reader.GetString(0);
                    title = reader.GetString(1);
                    copies = reader.GetInt32(2);
                    Rating = reader.GetInt32(3);
                    location = reader.GetString(4);
                    author = reader.GetString(5);
                    Book book = new Book(title, author, Id, copies, Rating, location);
                    FoundBooks.Add(book);
                }
                return FoundBooks;
            }
        }
        public List<Loan> GetLoanFromDatabase(IUser user)
        {
            string LoanID;
            string BookId;
            DateTime DateBorrowed;
            DateTime DateDue;
            bool IsActive;
            string reservationID;
            string userType;
            List<Loan> loans = new List<Loan>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "(Select LoanID,BookID,IsActive,DateBorrowed,DateDue,UserType from loan where userID='" + user.ID + "' and IsActive=true);";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LoanID = reader.GetString(0);
                    BookId = reader.GetString(1);
                    IsActive = reader.GetBoolean(2);
                    DateBorrowed = reader.GetDateTime(3);
                    DateDue = reader.GetDateTime(4);
                    userType = reader.GetString(5);

                    Book book = GetBookFromDatabase(BookId);
                    Loan loan = new Loan(LoanID, book, user, DateBorrowed, DateDue);
                    loans.Add(loan);
                }
                return loans;
            }




        }
        public Loan GetLoanUsingId(IUser user,string ID)
        {
            List<Loan> loans=new List<Loan>();
            string BookId="";
            DateTime DateBorrowed ;
            DateTime DateDue;
            bool IsActive;
            string reservationID;
            string userType;
            Loan loan = new Loan();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "(Select BookID,IsActive,DateBorrowed,DateDue,UserType from loan where userID='" + user.ID + "' and IsActive=true and LoanID='" + ID + "');";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BookId = reader.GetString(0);
                    IsActive = reader.GetBoolean(1);
                    DateBorrowed = reader.GetDateTime(2);
                    DateDue = reader.GetDateTime(3);
                    userType = reader.GetString(4);

                    Book book = GetBookFromDatabase(BookId);
                    loan = new Loan(ID, book, user, DateBorrowed, DateDue);
                }
                return loan;


            }




        }


        public int CountRowsReservation()
        {
            int count = 0;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "Select Count(*) from reservation;";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                return count;
            }

        }

        public List<Fine>GetFinesFromDatabase(IUser user)
        {
            string FineID;
            string LoanId;
            int amount;
            bool IsActive;
            string reservationID;
            string userType;
            List<Fine> fines = new List<Fine>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "(Select FineID,LoanID,UserType,IsActive,FineAmount from fine where userID='" + user.ID + "' and IsActive=true);";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    FineID = reader.GetString(0);
                    LoanId = reader.GetString(1);
                    userType = reader.GetString(2);

                    IsActive = reader.GetBoolean(3);
                    amount = reader.GetInt32(4);
                    Loan loan = GetLoanUsingId(user, LoanId);
                    Fine fine = new Fine(FineID,user,amount,loan);
                    fines.Add(fine);
                }
                return fines;
            }
        }

        public List<Student> GetAllStudentsFromDatabase()
        {
            List<Student> students = new List<Student>();
            string StudentId = "";
            int studentid;
            string password;
            string Name = "";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "Select StudentId,Password,Name from student;";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentId= reader.GetString(0);
                    studentid = Convert.ToInt32(StudentId);
                    password = reader.GetString(1);
                    Name= reader.GetString(2);
                    Student student= new Student(Name,studentid, password);
                    students.Add(student);
                }
                return students;
            }

        }

        public List<Instructor> GetAllInstructorsFromDatabase()
        {
            List<Instructor> Instructors = new List<Instructor>();
            int InstructorId;
            string instructorid="";
            string Password;
            string Name = "";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "Select InstructorID,Password,InstructorName from instructor;";
                MySqlCommand command = new MySqlCommand(sql, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    instructorid = reader.GetString(0);
                    InstructorId = Convert.ToInt32(instructorid);
                    Password = reader.GetString(1);
                    Name = reader.GetString(2);
                    Instructor instructor = new Instructor(Name,InstructorId, Password);
                   Instructors.Add(instructor);
                }
                return Instructors;
            }

        }
    }
}
