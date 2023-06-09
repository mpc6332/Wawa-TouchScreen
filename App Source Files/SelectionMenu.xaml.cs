using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Lab_WawaApp;

/// <summary>
///     Interaction logic for SelectionMenu.xaml
/// </summary>
public partial class SelectionMenu : Window
{
    private readonly Window currentWindow;
    private readonly List<ScreenSessionRecord> ScreenSessionList = new();
    private readonly List<WawaItem> WawaItemsList = new();
    private readonly string currentWindowString = "SelectionMenu";

    public SelectionMenu(List<ScreenSessionRecord> screenSessionRecord)
    {
        InitializeComponent();
        ScreenSessionList = screenSessionRecord;
        currentWindow = GetWindow(this);
    }

    // When the hoagie image is clicked on, take the user to the Hoagie selection menu.
    private void img_HoagieSelection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Records the window session and adds it to a list/stack
        var selectionMenuHoagieSession = SessionCreation(currentWindowString);
        ScreenSessionList.Add(selectionMenuHoagieSession);

        var hoagieWindowSession = new HoagieWindow(WawaItemsList, ScreenSessionList);
        Close();
        hoagieWindowSession.ShowDialog();
    }

    // When the soups/sides image is clicked on, take the user to the Soups and Sides selection menu.
    private void img_SoupAndSidesSelection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Records the window session and adds it to a list/stack
        var selectionMenuHoagieSession = SessionCreation(currentWindowString);
        ScreenSessionList.Add(selectionMenuHoagieSession);

        var soupsAndSidesSession = new SoupsAndSidesWindow(WawaItemsList, ScreenSessionList);
        Close();
        soupsAndSidesSession.ShowDialog();
    }

    // When the hot/cold beverages image is clicked on, take the user to the hot/cold beverage selection menu
    // (Note: this just only leads the user to the window that has them choose between cold or hot drinks.
    // The drinks themselves aren't present until you select one of those options.
    // Even then, you'll only be able to select 3 cold drinks and 2 hot drinks respectively).
    private void img_BeveragesSelection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Records the window session and adds it to a list/stack
        var selectionMenuHoagieSession = SessionCreation(currentWindowString);
        ScreenSessionList.Add(selectionMenuHoagieSession);

        var hotAndColdBeverageWindowSession = new HotAndColdBeverageWindow(WawaItemsList, ScreenSessionList);
        Close();
        hotAndColdBeverageWindowSession.ShowDialog();
    }

    // When the "Previous Button" image is clicked on, take the user to the previous screen.
    private void img_previousButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ScreenSessionRecord.previousButtonExecuted(WawaItemsList, ScreenSessionList, currentWindow);
    }



    // When the "En Español" is clicked, load up a message box that depicts simple ascii art of a sombrero alongside a greeting.
    private void img_SpanishLanguageOption_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("                      _-'-_\r\n" +
                        "                    /_-_-_\\\r\n" +
                        "        _______|-_-_-_-|________\r\n" +
                        "      (________________________)\r\n" +
                        "       !   !   !   !   !   !   !   !   !   !\r\n\r\n" +
                        "¡Hola! Espero que estés teniendo un buen día!");
    }

    // When the "Allergen warning" is clicked on, load up a message box that explains to the use how to access and use Wawa's nutrition needs chart.
    private void img_AllergenWarning_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(
            "Allergen Info for Your Dietary Needs\n\n\nAt Wawa, we pride ourselves on offering food and beverage options that all of our customers can enjoy. " +
            "Use the tool below (Go to \"https://www.wawa.com/fresh-food/nutrition-quality-food/nutrition\" and then hit the \"ALLERGEN INFORMATION\" tab)" +
            " to filter to the allergen information most relevant to you or your loved ones.");
    }

    // When the "Gobbler is back" AD image is clicked on, load up a message box that explains the details pertaining to it.
    private void img_AD_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(
            "We actually are NOT serving the Gobbler at this time. Although, maybe you should try out our \"Chicken Cheese Steak\" from our \"Hoagies & Sandwiches\" section!");
    }

    // When the "Chalupa Hoagie" AD image is clicked on, load up a message box that explains the details pertaining to it.
    private void img_AD_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(
            "While we are not currently serving the Chalupa Hoagie, we do serve lemonade. That can be found in the \"Cold beverages\" sub section within the \"Beverages\" selection menu!");
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