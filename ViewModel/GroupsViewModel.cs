using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using StudentsGraduationProject.Model.Entities;
using StudentsGraduationProject.Model.Context;
using StudentsGraduationProject.Model.CRUD;
using StudentsGraduationProject.View;

namespace StudentsGraduationProject.ViewModel;

internal class GroupsViewModel : ViewModelBase, ICrudViewModel
{
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

    private string gp;

    public string Gp
    {
        get => gp;
        set
        {
            gp = value;
            OnPropertyChanged(nameof(gp));
        }
    }

    private int cfacl;

    public int CFacl
    {
        get => cfacl;
        set
        {
            cfacl = value;
            OnPropertyChanged(nameof(cfacl));
        }
    }

    private ObservableCollection<Group> groups;

    public ObservableCollection<Group> Groups
    {
        get => groups;
        set
        {
            groups = value;
            OnPropertyChanged(nameof(groups));
        }
    }

    private Window currentWindow;

    private Group selectedGroup;

    public Group SelectedGroup
    {
        get => selectedGroup;
        set
        {
            selectedGroup = value;
            OnPropertyChanged(nameof(selectedGroup));
            if (selectedGroup != null)
            {
                CGp = selectedGroup.CGp;
                CFacl = selectedGroup.CFacl;
                Gp = selectedGroup.Gp;
            }
        }
    }

    public ICommand Create { get; private set; }

    public ICommand Delete { get; private set; }

    public ICommand Update { get; private set; }


    public GroupsViewModel(Window window)
    {
        currentWindow = window;
        Create = new Command(CreateGroup);
        Update = new Command(RemoveGroup);
        Delete = new Command(UpdateGroup);
        OpenStudentsCommand = new Command(OpenStudentsView);
        OpenFacultyCommand = new Command(OpenFacultyView);
        OpenTeacherCommand = new Command(OpenTeacherView);
        OpenDiplomCommand = new Command(OpenDiplomThemeView);
        IRepository<Group> repository = new Repository<Group>(new ApplicationContext<Group>());
        Groups = new(repository.Read());
        repository.CloseConnection();
    }

    private void CreateGroup(object obj)
    {
        if (cgp != default && cfacl != default && !string.IsNullOrEmpty(gp))
        {
            IRepository<Group> repository = new Repository<Group>(new ApplicationContext<Group>());
            Group group = new() { CFacl = cfacl, CGp = cgp, Gp = gp };
            repository.Create(group);
            repository.CloseConnection();
            Groups.Add(group);            
        }
    }

    private void RemoveGroup(object obj)
    {
        if (selectedGroup != null)
        {
            IRepository<Group> repository = new Repository<Group>(new ApplicationContext<Group>());
            repository.Delete(selectedGroup);
            repository.CloseConnection();
            Groups.Remove(selectedGroup);
        }
    }

    private void UpdateGroup(object obj)
    {
        if (selectedGroup != null)
        {
            IRepository<Group> repository = new Repository<Group>(new ApplicationContext<Group>());
            Group group = new() { CGp = selectedGroup.CGp, CFacl = cfacl, Gp = gp };
            repository.Update(selectedGroup.CGp, group);
            repository.CloseConnection();
            int index = Groups.IndexOf(Groups.First(item => item.CGp == group.CGp));
            Groups[index] = group;
        }
    }

    public ICommand OpenStudentsCommand { get; private set; }

    private void OpenStudentsView(object obj)
    {
        StudentView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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

    public ICommand OpenDiplomCommand { get; private set; }

    private void OpenDiplomThemeView(object obj)
    {
        DiplomThemeView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }

    public ICommand OpenTeacherCommand { get; private set; }

    private void OpenTeacherView(object obj)
    {
        TeacherView view = new();
        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        view.Show();
        currentWindow.Close();
    }
}
