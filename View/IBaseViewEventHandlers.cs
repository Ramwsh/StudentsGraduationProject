using System.Windows;
using System.Windows.Input;

namespace StudentsGraduationProject.View;

internal interface IBaseViewEventHandlers
{
    void Exit_Click(object sender, RoutedEventArgs e);

    void Drag_MouseDown(object sender, MouseButtonEventArgs e);    
}
