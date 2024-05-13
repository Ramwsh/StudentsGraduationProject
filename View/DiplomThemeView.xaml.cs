﻿using StudentsGraduationProject.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace StudentsGraduationProject.View;

public partial class DiplomThemeView : Window, IBaseViewEventHandlers
{
    public DiplomThemeView()
    {
        InitializeComponent();
        DataContext = new DiplomThemeViewModel(this);
    }

    public void Drag_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (Mouse.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }
    
    private void PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!char.IsDigit(e.Text, e.Text.Length - 1))
        {
            e.Handled = true;
        }
    }

    public void Exit_Click(object sender, RoutedEventArgs e) => Environment.Exit(0);
}
