using StudentsGraduationProject.View;
using System.Windows;
using System.Windows.Input;

namespace StudentsGraduationProject.ViewModel;

internal class MainViewModel
{
    private Window currentWindow;

    public ICommand OpenDiplomViewCommand { get; private set; }

    public ICommand OpenFacultyViewCommand { get; private set; }

    public ICommand OpenGroupsViewCommand { get; private set; }

    public ICommand OpenStudentsViewCommand { get; private set; }

    public ICommand OpenTeacherViewCommand { get; private set; }

    public MainViewModel(Window window)
    {
        currentWindow = window;
        OpenDiplomViewCommand = new Command(OpenDiplomThemesView);
        OpenFacultyViewCommand = new Command(OpenFacultyView);
        OpenGroupsViewCommand = new Command(OpenGroupsView);
        OpenStudentsViewCommand = new Command(OpenStudentsView);
        OpenTeacherViewCommand = new Command(OpenTeacherView);
    }    

    private void OpenDiplomThemesView(object obj)
    {
        DiplomThemeView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    private void OpenFacultyView(object obj)
    {        
        FacultyView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    private void OpenGroupsView(object obj)
    {
        GroupsView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    private void OpenStudentsView(object obj)
    {
        StudentView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    private void OpenTeacherView(object obj)
    {
        TeacherView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }
}
