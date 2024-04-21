using System.Collections.ObjectModel;
using FinalProjectLibraryManagerV01E.Models;
using FinalProjectLibraryManagerV01E.Models.Managers;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class StudentsInstructors : ContentPage
{
	public StudentsInstructors()
	{
		InitializeComponent();
        BindData();
        
    }

    private void homeUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageLibrarian)); ;
    }

    private void booksUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BooksPage));
    }

    private void searchUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelect));
    }

    private void reservationsUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ReservationPage));
    }

    private void loansUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoansPage));
    }

    private void finesPaymentsUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ActiveFinesPayments));
    }

    private void LogoutUsersAdminBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }
    public List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();
        students = UserManager.GetStudentsFromManager();
        return students;
    }
    public List<Instructor> GetAllInstructors()
    {
        List<Instructor> instructors = new List<Instructor>();
        instructors = UserManager.GetInstructorFromManager();
        return instructors;
    }

    public void BindData()
    {
        List<Student> students=GetAllStudents();
        List<Instructor> instructors = GetAllInstructors();
        //var viewModel = new StudentsInstructors
        //{
        //    Students = new ObservableCollection<Student>(students),
        //    Instructors = new ObservableCollection<Instructor>(instructors)
        //};

        //// Set the ViewModel instance as the BindingContext
        //BindingContext = viewModel;
        StudentListView.ItemsSource=students;
        InstructorListView.ItemsSource=instructors;

    }
}