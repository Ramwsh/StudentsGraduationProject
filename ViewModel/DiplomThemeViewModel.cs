using StudentsGraduationProject.Model.CRUD;
using StudentsGraduationProject.Model.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using StudentsGraduationProject.Model.Context;
using System.Windows.Input;
using StudentsGraduationProject.View;

namespace StudentsGraduationProject.ViewModel;

internal class DiplomThemeViewModel : ViewModelBase, ICrudViewModel
{
    private Window currentWindow;

    private int csub;

    public int CSub
    {
        get => csub;
        set
        {
            csub = value;
            OnPropertyChanged(nameof(csub));
        }
    }

    private string sub;

    public string Sub
    {
        get => sub;
        set
        {
            sub = value;
            OnPropertyChanged(nameof(sub));
        }
    }

    private int ctch;

    public int CTch
    {
        get => ctch;
        set
        {
            ctch = value;
            OnPropertyChanged(nameof(ctch));
        }
    }

    private DiplomTheme selectedDiplomTheme;

    public DiplomTheme SelectedDiplomTheme
    {
        get => selectedDiplomTheme;
        set
        {
            selectedDiplomTheme = value;
            OnPropertyChanged(nameof(selectedDiplomTheme));
            if (selectedDiplomTheme != null)
            {
                CSub = selectedDiplomTheme.CSub;
                Sub = selectedDiplomTheme.Sub;
                CTch = selectedDiplomTheme.CTch;                
            }
        }
    }

    private ObservableCollection<DiplomTheme> diplomThemes;

    public ObservableCollection<DiplomTheme> DiplomThemes
    {
        get => diplomThemes;
        set
        {
            diplomThemes = value;
            OnPropertyChanged(nameof(diplomThemes));
        }
    }

    public DiplomThemeViewModel(Window window)
    {
        currentWindow = window;
        Create = new Command(CreateDiplomTheme);
        Delete = new Command(DeleteDiplomTheme);
        Update = new Command(UpdateDiplomTheme);
        OpenFacultyCommand = new Command(OpenFacultyView);
        OpenGroupCommand = new Command(OpenGroupView);
        OpenStudentCommand = new Command(OpenStudentView);
        OpenTeacherCommand = new Command(OpenTeacherView);
        IRepository<DiplomTheme> repository = new Repository<DiplomTheme>(new ApplicationContext<DiplomTheme>());
        DiplomThemes = new(repository.Read());
        repository.CloseConnection();
    }

    public ICommand Delete { get; private set; }

    private void DeleteDiplomTheme(object obj)
    {
        if (selectedDiplomTheme != null)
        {
            IRepository<DiplomTheme> repository = new Repository<DiplomTheme>(new ApplicationContext<DiplomTheme>());
            repository.Delete(selectedDiplomTheme);
            repository.CloseConnection();
            DiplomThemes.Remove(selectedDiplomTheme);            
        }
    }

    public ICommand Create { get; private set; }

    private void CreateDiplomTheme(object obj)
    {        
        if (ctch != default && !string.IsNullOrWhiteSpace(sub) && csub != default)
        {
            IRepository<DiplomTheme> repository = new Repository<DiplomTheme>(new ApplicationContext<DiplomTheme>());
            DiplomTheme theme = new() { CSub = csub, CTch = ctch, Sub = sub };
            repository.Create(theme);            
            repository.CloseConnection();
            DiplomThemes.Add(theme);            
        }
    }

    public ICommand Update { get; private set; }

    private void UpdateDiplomTheme(object obj)
    {
        if (selectedDiplomTheme != null)
        {
            IRepository<DiplomTheme> repository = new Repository<DiplomTheme>(new ApplicationContext<DiplomTheme>());
            DiplomTheme theme = new() { CSub = selectedDiplomTheme.CSub, CTch = ctch, Sub = sub };
            repository.Update(selectedDiplomTheme.CSub, theme);
            repository.CloseConnection();
            int unchangedItemIndex = DiplomThemes.IndexOf(DiplomThemes.First(item => item.CSub == selectedDiplomTheme.CSub));
            DiplomThemes[unchangedItemIndex] = theme;
        }
    }

    public ICommand OpenStudentCommand { get; private set; }
    private void OpenStudentView(object obj)
    {
        StudentView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    public ICommand OpenGroupCommand { get; private set; }
    private void OpenGroupView(object obj)
    {
        GroupsView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    public ICommand OpenTeacherCommand { get; private set; }
    private void OpenTeacherView(object obj)
    {
        TeacherView view = new();
        view.WindowStartupLocation= WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    public ICommand OpenFacultyCommand { get; private set; }
    private void OpenFacultyView(object obj)
    {
        FacultyView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }
}
