using StudentsGraduationProject.Model.Context;
using StudentsGraduationProject.Model.CRUD;
using StudentsGraduationProject.Model.Entities;
using StudentsGraduationProject.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace StudentsGraduationProject.ViewModel
{
    internal class FacultyViewModel : ViewModelBase, ICrudViewModel
    {
        private Window currentWindow;

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

        private string facl;

        public string Facl
        {
            get => facl;
            set
            {
                facl = value;
                OnPropertyChanged(nameof(facl));
            }
        }

        private ObservableCollection<Faculty> faculties;

        public ObservableCollection<Faculty> Faculties
        {
            get => faculties;
            set
            {
                faculties = value;
                OnPropertyChanged(nameof(faculties));
            }
        }

        private Faculty selectedFaculty;

        public Faculty SelectedFaculty
        {
            get => selectedFaculty;
            set
            {
                selectedFaculty = value;
                OnPropertyChanged(nameof(selectedFaculty));
                if (selectedFaculty != null)
                {
                    CFacl = selectedFaculty.CFacl;
                    Facl = selectedFaculty.Facl;
                }
            }
        }

        public ICommand Create { get; private set; }
        public ICommand Delete { get; private set; }
        public ICommand Update { get; private set; }

        public FacultyViewModel(Window window)
        {            
            currentWindow = window;
            IRepository<Faculty> repository = new Repository<Faculty>(new ApplicationContext<Faculty>());
            Faculties = new(repository.Read());
            repository.CloseConnection();
            Create = new Command(CreateFaculty);
            Delete = new Command(RemoveFaculty);
            Update = new Command(UpdateFaculty);
            OpenDiplomThemeViewCommand = new Command(OpenDiplomThemeView);
            OpenStudentViewCommand = new Command(OpenStudentView);
            OpenGroupViewCommand = new Command(OpenGroupView);
            OpenTeacherViewCommand = new Command(OpenTeacherView);
        }

        private void CreateFaculty(object obj)
        {
            if (cfacl != default && !string.IsNullOrWhiteSpace(facl))
            {
                IRepository<Faculty> repository = new Repository<Faculty>(new ApplicationContext<Faculty>());
                Faculty faculty = new() { CFacl = cfacl, Facl = facl };
                repository.Create(faculty);
                repository.CloseConnection();
                Faculties.Add(faculty);
            }
        }

        private void RemoveFaculty(object obj)
        {
            if (selectedFaculty != null)
            {
                IRepository<Faculty> repository = new Repository<Faculty>(new ApplicationContext<Faculty>());
                repository.Delete(selectedFaculty);
                repository.CloseConnection();
                Faculties.Remove(selectedFaculty);
            }
        }

        private void UpdateFaculty(object obj)
        {
            if (selectedFaculty != null)
            {
                IRepository<Faculty> repository = new Repository<Faculty>(new ApplicationContext<Faculty>());
                Faculty faculty = new() { CFacl = selectedFaculty.CFacl, Facl = facl };
                repository.Update(selectedFaculty.CFacl,faculty);
                repository.CloseConnection();
                int index = Faculties.IndexOf(Faculties.First(item => item.CFacl == faculty.CFacl));
                Faculties[index] = faculty;
            }
        }
        
        public ICommand OpenDiplomThemeViewCommand { get; private set; }
        private void OpenDiplomThemeView(object obj)
        {
            DiplomThemeView view = new();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            currentWindow.Close();
        }

        public ICommand OpenStudentViewCommand { get; private set; }
        private void OpenStudentView(object obj)
        {
            StudentView view = new();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            currentWindow.Close();
        }

        public ICommand OpenTeacherViewCommand { get; private set; }
        private void OpenTeacherView(object obj)
        {
            TeacherView view = new();
            view.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            view.Show();
            currentWindow.Close();
        }

        public ICommand OpenGroupViewCommand { get; private set; }
        private void OpenGroupView(object obj)
        {
            GroupsView view = new();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            currentWindow.Close();
        }
    }
}
