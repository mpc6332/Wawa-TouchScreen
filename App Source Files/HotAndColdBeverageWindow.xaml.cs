using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Lab_WawaApp;

/// <summary>
///     Interaction logic for HotAndColdBeverageWindow.xaml
/// </summary>
public partial class HotAndColdBeverageWindow : Window
{
    private readonly Window currentWindow;
    private readonly List<ScreenSessionRecord> ScreenSessionList = new();
    private readonly List<WawaItem> WawaItemsList = new();
    private readonly string currentWindowString = "HotAndColdBeverageWindow";

    public HotAndColdBeverageWindow(List<WawaItem> wawaItemsList, List<ScreenSessionRecord> screenSessionRecords)
    {
        InitializeComponent();
        WawaItemsList = wawaItemsList;
        ScreenSessionList = screenSessionRecords;
        currentWindow = GetWindow(this);
    }

    // When the Textbox is loaded, list all of the elements that are stored in the WawaItemsList
    private void txt_MyOrderList_Loaded(object sender, RoutedEventArgs e)
    {
        for (var i = 0; i < WawaItemsList.Count; i++) txt_MyOrderList.Text += WawaItemsList[i] + "\n\n\n";
    }

    // When the hot beverage image is clicked on, take the user to the hot beverage menu.
    // There should be two drinks to select from.
    private void img_hotBeveragesOption_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Records the window session and adds it to a list/stack
        var hotAndColdBeverageWindowSession = SessionCreation(currentWindowString);
        ScreenSessionList.Add(hotAndColdBeverageWindowSession);

        var hotBeveragesWindowSession_1 = new HotBeveragesWindow(WawaItemsList, ScreenSessionList);
        Close();
        hotBeveragesWindowSession_1.ShowDialog();
    }

    // When the cold beverage image is clicked on, take the user to the hot beverage menu.
    // There should be two drinks to select from.
    private void img_coldBeveragesOption_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Records the window session and adds it to a list/stack
        var hotAndColdBeverageWindowSession = SessionCreation(currentWindowString);
        ScreenSessionList.Add(hotAndColdBeverageWindowSession);

        var coldBeveragesWindowSession_1 = new ColdBeveragesWindow(WawaItemsList, ScreenSessionList);
        Close();
        coldBeveragesWindowSession_1.ShowDialog();
    }

    // When the "Previous Button" image is clicked on, take the user to the previous screen.
    private void img_previousButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ScreenSessionRecord.previousButtonExecuted(WawaItemsList, ScreenSessionList, currentWindow);
    }

    // Create an object that records the details of the screen session
    private ScreenSessionRecord SessionCreation(string windowName)
    {
        // Create a new session object and set its properties based on the parsed fields.
        var objectName = new ScreenSessionRecord
        {
            WindowName = windowName
        };
        return objectName;
    }
}