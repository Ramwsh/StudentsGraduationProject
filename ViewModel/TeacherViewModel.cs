using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using StudentsGraduationProject.Model.Context;
using StudentsGraduationProject.Model.CRUD;
using StudentsGraduationProject.Model.Entities;
using StudentsGraduationProject.View;

namespace StudentsGraduationProject.ViewModel;

internal class TeacherViewModel : ViewModelBase
{
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

    private string fntch;

    public string FNTch
    {
        get => fntch;
        set
        {
            fntch = value;
            OnPropertyChanged(nameof(fntch));
        }
    }

    private string dtch;

    public string DTch
    {
        get => dtch;
        set
        {
            dtch = value;
            OnPropertyChanged(nameof(dtch));
        }
    }

    private string rtch;
    
    public string RTch
    {
        get => rtch;
        set
        {
            rtch = value;
            OnPropertyChanged(nameof(rtch));
        }
    }

    private string deptch;

    public string DepTch
    {
        get => deptch;
        set
        {
            deptch = value;
            OnPropertyChanged(nameof(deptch));
        }
    }

    private string pntch;

    public string PnTch
    {
        get => pntch;
        set
        {
            pntch = value;
            OnPropertyChanged(nameof(pntch));
        }
    }

    private string email;

    public string Email
    {
        get => email;
        set
        {
            email = value;
            OnPropertyChanged(nameof(email));
        }
    }

    private Window currentWindow;

    private ObservableCollection<Teacher> teachers;

    public ObservableCollection<Teacher> Teachers
    {
        get => teachers;
        set
        {
            teachers = value;
            OnPropertyChanged(nameof(teachers));
        }
    }

    private Teacher selectedTeacher;

    public ICommand Create { get; private set; }
    public ICommand Update { get; private set; }
    public ICommand Remove { get; private set; }

    public Teacher SelectedTeacher
    {
        get => selectedTeacher;
        set
        {
            selectedTeacher = value;
            OnPropertyChanged(nameof(selectedTeacher));
            if (selectedTeacher != null)
            {
                CTch = selectedTeacher.CTch;
                FNTch = selectedTeacher.FNTch;
                DTch = selectedTeacher.DTch;
                RTch = selectedTeacher.RTch;
                DepTch = selectedTeacher.DepTch;
                PnTch = selectedTeacher.PnTch;
                Email = selectedTeacher.Email;
            }
        }
    }

    public TeacherViewModel(Window window)
    {
        Create = new Command(CreateTeacher);
        Update = new Command(UpdateTeacher);
        Remove = new Command(RemoveTeacher);
        OpenDiplomThemeCommand = new Command(OpenDiplomThemeView);
        OpenFacultyCommand = new Command(OpenFacultyView);
        OpenGroupCommand = new Command(OpenGroupView);
        OpenStudentCommand = new Command(OpenStudentView);
        currentWindow = window;
        IRepository<Teacher> repository = new Repository<Teacher>(new ApplicationContext<Teacher>());
        Teachers = new(repository.Read());
        repository.CloseConnection();
    }

    private void CreateTeacher(object obj)
    {
        if (ctch != default && !string.IsNullOrWhiteSpace(fntch) && !string.IsNullOrWhiteSpace(dtch) && !string.IsNullOrWhiteSpace(rtch) && !string.IsNullOrWhiteSpace(deptch) && !string.IsNullOrWhiteSpace(pntch) && !string.IsNullOrWhiteSpace(email))
        {
            IRepository<Teacher> repository = new Repository<Teacher>(new ApplicationContext<Teacher>());
            Teacher teacher = new() { CTch = ctch, FNTch = fntch, DTch = dtch, RTch = rtch, DepTch = deptch, PnTch = pntch, Email = email };
            repository.Create(teacher);
            repository.CloseConnection();
            Teachers.Add(teacher);
        }
    }

    private void UpdateTeacher(object obj)
    {
        if (selectedTeacher != null)
        {
            IRepository<Teacher> repository = new Repository<Teacher>(new ApplicationContext<Teacher>());
            Teacher teacher = new() { CTch = selectedTeacher.CTch, FNTch = fntch, DTch = dtch, RTch = rtch, DepTch = deptch, PnTch = pntch, Email = email };
            repository.Update(selectedTeacher.CTch, teacher);
            repository.CloseConnection();
            int index = Teachers.IndexOf(Teachers.First(item => item.CTch == teacher.CTch));
            Teachers[index] = teacher;
        }        
    }

    private void RemoveTeacher(object obj)
    {
        if (selectedTeacher != null)
        {
            IRepository<Teacher> repository = new Repository<Teacher>(new ApplicationContext<Teacher>());
            repository.Delete(selectedTeacher);
            repository.CloseConnection();
            Teachers.Remove(selectedTeacher);
        }
    }

    public ICommand OpenStudentCommand { get; private set; }
    public ICommand OpenFacultyCommand { get; private set; }
    public ICommand OpenGroupCommand { get; private set; }
    public ICommand OpenDiplomThemeCommand { get; private set; }

    private void OpenStudentView(object obj)
    {
        StudentView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    private void OpenFacultyView(object obj)
    {
        FacultyView view = new();
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

    private void OpenDiplomThemeView(object obj)
    {
        DiplomThemeView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }
}
