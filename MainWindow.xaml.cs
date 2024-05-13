using StudentsGraduationProject.View;
using StudentsGraduationProject.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace StudentsGraduationProject;

public partial class MainWindow : Window, IBaseViewEventHandlers
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel(this);
    }

    public void Exit_Click(object sender, RoutedEventArgs e) => Environment.Exit(0);

    public void Drag_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (Mouse.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
}