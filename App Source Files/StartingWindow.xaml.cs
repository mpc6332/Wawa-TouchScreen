using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Lab_WawaApp;

/// <summary>
///     Interaction logic for StartingWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly List<ScreenSessionRecord> ScreenSessionList = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    // Pressing down on the grid will take the user to the item selection menu
    private void grd_startingWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Records the window session and adds it to a list/stack
        var startingWindowSession = new ScreenSessionRecord
        {
            WindowName = "StartingWindow"
        };
        
        ScreenSessionList.Add(startingWindowSession);

        var startWindowSession = new SelectionMenu(ScreenSessionList);
        Close();
        startWindowSession.ShowDialog();
    }
}