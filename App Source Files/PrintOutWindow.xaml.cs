using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Lab_WawaApp;

/// <summary>
///     Interaction logic for PrintOutWindow.xaml
/// </summary>
public partial class PrintOutWindow : Window
{
    private readonly Window currentWindow;
    private readonly string currentWindowString = "PrintOutWindow";
    private readonly List<ScreenSessionRecord> ScreenSessionList = new();
    private readonly List<WawaItem> WawaItemsList = new();
    private string popUpWindowAnswer;

    public PrintOutWindow(List<WawaItem> wawaItemsList, List<ScreenSessionRecord> screenSessionRecords)
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

    // When the hoagie image is clicked on, take the user to the Hoagie selection menu.
    private void img_HoagieSelection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var printOutWindowSession = SessionCreation(currentWindowString);
        ScreenSessionList.Add(printOutWindowSession);
        var hoagieWindowSession = new HoagieWindow(WawaItemsList, ScreenSessionList);
        Close();
        hoagieWindowSession.ShowDialog();
    }

    // When the soups/sides image is clicked on, take the user to the Soups and Sides selection menu.
    private void img_SoupAndSidesSelection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var printOutWindowSession = SessionCreation(currentWindowString);
        ScreenSessionList.Add(printOutWindowSession);
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
        var printOutWindowSession = SessionCreation(currentWindowString);
        ScreenSessionList.Add(printOutWindowSession);
        var hotAndColdBeverageWindowSession = new HotAndColdBeverageWindow(WawaItemsList, ScreenSessionList);
        Close();
        hotAndColdBeverageWindowSession.ShowDialog();
    }

    // When the "Energy Refreshers" AD image is clicked on, load up a message box that explains the details pertaining to it.
    private void img_printOutAd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(
            "\"At Wawa, we know that sometimes you need a little pick-me-up to get through your day. That's why we've got a whole range of energy refreshers to help you power through whatever life throws your way.\r\n\r\n" +
            "Our energy refreshers are more refreshing than a dip in the ocean on a hot summer day, and they're packed with the kind of energy that will keep you going all day long. Whether you need a jolt of caffeine or a burst of fruity flavor, we've got you covered.\r\n\r\n" +
            "And the best part? Our energy refreshers are made with real, high-quality ingredients, so you can feel good about what you're putting in your body. No weird chemicals or artificial flavors here - just pure, delicious refreshment.\"");
    }

    // When you click the "add quantity" image, a message box appears that tells a corny statistics joke.
    // There is also a depiction that shows a baffled emoticon in respond to the joke.
    private void img_updateQuantity_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(
            "♠  ♥  ♦  ♣\n\"Why did the statistician bring a deck of cards to his meeting?\n Because he wanted to show his colleagues the 'probability' of \n getting their project done on time!\"\n\n¯\\(°_o)/¯" +
            "\n\nOn a side note, you can add another quantity of an item by going through the selection process again. Remember that some of the items you select have their spreads/sauces/toppings/etc preconfigured.");
    }

    // When you click the "Select another item" image, a message box appears that there is no need to click this
    // since all of the options from the selection menu are present here.
    private void img_selectAnotherItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(
            "There is no need to click on this since all of the options from the other selection menu (hoagies, soups/sides, beverages) are here." +
            "\nInstead, just click on one of those three options that are located at the top of the screen.");
    }

    // When you click the "special order" image, a message box appears that depicts an emoticon flipping over a table.
    // Presumably, this is because the "button" doesn't have any functionality to it.
    private void img_specialOrder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("(╯°□°)╯彡┻━┻");
    }


    // When the "Previous Button" image is clicked on, take the user to the previous screen.
    private void img_previousButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ScreenSessionRecord.previousButtonExecuted(WawaItemsList, ScreenSessionList, currentWindow);
    }

    // When the "Cancel Button" image is clicked on, show a pop-up window that prompts the user if they want to proceed with their choice.
    // If so, clear out all of the running lists and go back to the starting window.
    private void img_cancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        PopUpWindow popUpWindow = new PopUpWindow();
        popUpWindow.ShowDialog();
        popUpWindowAnswer = popUpWindow.AnswerChoice;

        if (popUpWindowAnswer == "OK")
        {
            ScreenSessionList.Clear();
            WawaItemsList.Clear();
            var newWindowSession = new MainWindow();
            Close();
            newWindowSession.ShowDialog();
        }
    }

    // When you click the "Complete & Print My order" image, it loads up a message box telling the final price alongside a randomly generated order number.
    // Afterwards, it terminates the program.
    private void img_PrintOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        decimal priceTotal = 0;
        var rand = new Random();
        var randomNumber = rand.Next(1, 101);
        for (var i = 0; i < WawaItemsList.Count; i++) priceTotal += WawaItemsList[i].Price * WawaItemsList[i].QTY;
        MessageBox.Show("Order #" + randomNumber + "\n" +
                        "Total Price:  $" + priceTotal + "\n\n" +
                        "Thank you for choosing Wawa!");
        Application.Current.Shutdown();
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