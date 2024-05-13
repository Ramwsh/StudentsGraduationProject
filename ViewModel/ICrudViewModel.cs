using System.Windows.Input;

namespace StudentsGraduationProject.ViewModel;

internal interface ICrudViewModel
{
    ICommand Create { get; }
    ICommand Delete { get; }
    ICommand Update { get; }
}
