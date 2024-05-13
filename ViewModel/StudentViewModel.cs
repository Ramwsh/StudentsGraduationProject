using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using StudentsGraduationProject.Model.Context;
using StudentsGraduationProject.Model.CRUD;
using StudentsGraduationProject.Model.Entities;
using StudentsGraduationProject.View;

namespace StudentsGraduationProject.ViewModel;

internal class StudentViewModel : ViewModelBase, ICrudViewModel
{
    private int rbn;

    public int RBN
    {
        get => rbn;
        set
        {
            rbn = value;
            OnPropertyChanged(nameof(rbn));
        }
    }

    private string fnstud;

    public string FNStud
    {
        get => fnstud;
        set
        {
            fnstud = value;
            OnPropertyChanged(nameof(fnstud));
        }
    }

    private int cgp;

    public int CGp
    {
        get => cgp;
        set
        {
            cgp = value;
            OnPropertyChanged(nameof(cgp));
        }
    }

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

    private int ggw;

    public int GGW
    {
        get => ggw;
        set
        {
            ggw = value;
            OnPropertyChanged(nameof(ggw));
        }
    }

    private int gse;

    public int GSE
    {
        get => gse;

        set
        {
            gse = value;
            OnPropertyChanged(nameof(gse));
        }
    }

    private ObservableCollection<Student> students;

    public ObservableCollection<Student> Students
    {
        get => students;
        set
        {
            students = value;
            OnPropertyChanged(nameof(students));
        }
    }

    private Student selectedStudent;

    public Student SelectedStudent
    {
        get => selectedStudent;
        set
        {
            selectedStudent = value;
            OnPropertyChanged(nameof(selectedStudent));
            if (selectedStudent != null)
            {
                RBN = selectedStudent.RBN;
                FNStud = selectedStudent.FNStud;
                CGp = selectedStudent.CGp;
                CSub = selectedStudent.CSub;
                GGW = selectedStudent.GGW;
                GSE = selectedStudent.GSE;
            }
        }
    }

    private Window currentWindow;

    public ICommand Create { get; private set; }

    public ICommand Update { get; private set; }

    public ICommand Delete { get; private set; }

    public StudentViewModel(Window window)
    {
        Create = new Command(CreateStudent);
        Update = new Command(UpdateStudent);
        Delete = new Command(RemoveStudent);
        OpenDiplomThemeViewCommand = new Command(OpenDiplomThemeView);
        OpenFacultyViewCommand = new Command(OpenFacultyView);
        OpenTeacherViewCommand = new Command(OpenTeacherView);
        OpenGroupViewCommand = new Command(OpenGroupView);
        IRepository<Student> repository = new Repository<Student>(new ApplicationContext<Student>());
        Students = new(repository.Read());
        repository.CloseConnection();
        currentWindow = window;
    }

    private void CreateStudent(object obj)
    {
        if (rbn != default && !string.IsNullOrEmpty(fnstud) && cgp != default && csub != default && ggw != default && gse != default)
        {
            IRepository<Student> repository = new Repository<Student>(new ApplicationContext<Student>());
            Student student = new() { RBN = rbn, FNStud = fnstud, CGp = cgp, CSub = csub, GGW = ggw, GSE = gse };
            repository.Create(student);
            repository.CloseConnection();
            Students.Add(student);
        }
    }

    private void UpdateStudent(object obj)
    {
        if (selectedStudent != null)
        {
            IRepository<Student> repository = new Repository<Student>(new ApplicationContext<Student>());
            Student student = new() { RBN = selectedStudent.RBN, FNStud = fnstud, CGp = cgp, CSub = csub, GGW = ggw, GSE = gse };
            repository.Update(selectedStudent.RBN, student);
            repository.CloseConnection();
            int index = Students.IndexOf(Students.First(item => item.RBN == student.RBN));
            Students[index] = student;
        }
    }

    private void RemoveStudent(object obj)
    {
        if (selectedStudent != null)
        {
            IRepository<Student> repository = new Repository<Student>(new ApplicationContext<Student>());
            repository.Delete(selectedStudent);
            repository.CloseConnection();
            Students.Remove(selectedStudent);
        }
    }

    public ICommand OpenFacultyViewCommand { get; private set; }
    public ICommand OpenTeacherViewCommand { get; private set; }
    public ICommand OpenDiplomThemeViewCommand { get; private set; }
    public ICommand OpenGroupViewCommand { get; private set; }

    private void OpenFacultyView(object obj)
    {
        FacultyView view = new();
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

    private void OpenDiplomThemeView(object obj)
    {
        DiplomThemeView view = new();
        view.WindowStartupLocation= WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    private void OpenGroupView(object obj)
    {
        GroupsView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }
}
