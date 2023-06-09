using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Lab_WawaApp;

/// <summary>
///     Interaction logic for SoupsAndSidesWindow.xaml
/// </summary>
public partial class SoupsAndSidesWindow : Window
{
    private readonly Window currentWindow;
    private readonly string currentWindowString = "SoupsAndSidesWindow";
    private readonly List<ScreenSessionRecord> ScreenSessionList = new();
    private readonly List<WawaItem> WawaItemsList = new();
    private int foundIndex;
    private bool ItemIsInTheList;
    private string itemName;

    public SoupsAndSidesWindow(List<WawaItem> wawaItemsList, List<ScreenSessionRecord> screenSessionRecords)
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

    // When this option is clicked on (Soup: Chicken Noodle), add its details to the "myOrder" textbox list (Options/Extras/Condiments) are pre-configured, so no extra screens). Also, it takes the user to the Print out window to either check out or add another item. Close out this window as well.
    private void img_chickenNoodleSoup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "CHICKEN NOODLE";

        // Checks to see if there is an existing object that is tied to the string "CHICKEN NOODLE"
        ExistingItemCheck(itemName);

        // If there is an item named "CHICKEN NOODLE", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }

        // If there is NOT an item named "CHICKEN NOODLE", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var chickenNoodle = ItemCreation(itemName, 3.79m, 140, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(chickenNoodle);
        }

        // Records the window session and adds it to a list/stack
        var sidesNsoupsChickenNoodleSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(sidesNsoupsChickenNoodleSession);

        startPrintOutSession();
    }

    // When this option is clicked on (Soup: Tomato Bisque), add its details to the "myOrder" textbox list (Options/Extras/Condiments) are pre-configured, so no extra screens). Also, it takes the user to the Print out window to either check out or add another item. Close out this window as well.
    private void img_tomatoBisqueSoup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "TOMATO BISQUE";

        // Checks to see if there is an existing object that is tied to the string "TOMATO BISQUE"
        ExistingItemCheck(itemName);

        // If there is an item named "TOMATO BISQUE", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }
        // If there is NOT an item named "TOMATO BISQUE", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var tomatoBisque = ItemCreation(itemName, 4.99m, 330, 0);

            // Add the tomatoBisque WawaItem object to a list.
            WawaItemsList.Add(tomatoBisque);
        }

        // Records the window session and adds it to a list/stack
        var sidesNsoupsTomatoBisqueSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(sidesNsoupsTomatoBisqueSession);

        startPrintOutSession();
    }

    // When this option is clicked on (Side: Mashed potatoes), add its details to the "myOrder" textbox list (Options/Extras/Condiments) are pre-configured, so no extra screens). Also, it takes the user to the Print out window to either check out or add another item. Close out this window as well.
    private void img_mashedPotatoesSide_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "MASHED POTATOES";

        // Checks to see if there is an existing object that is tied to the string "MASHED POTATOES"
        ExistingItemCheck(itemName);

        // If there is an item named "MASHED POTATOES", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }
        // If there is NOT an item named "MASHED POTATOES", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var mashedPotatoes = ItemCreation(itemName, 5.29m, 770, 0);

            // Add the mashedPotatoes WawaItem object to a list.
            WawaItemsList.Add(mashedPotatoes);
        }

        // Records the window session and adds it to a list/stack
        var sidesNsoupsMashedPotatoesSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(sidesNsoupsMashedPotatoesSession);

        startPrintOutSession();
    }

    // When this option is clicked on (Side: Mac & Cheese), add its details to the "myOrder" textbox list (Options/Extras/Condiments) are pre-configured, so no extra screens). Also, it takes the user to the Print out window to either check out or add another item. Close out this window as well.
    private void img_macNCheeseSide_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "MAC & CHEESE";

        // Checks to see if there is an existing object that is tied to the string "MAC & CHEESE"
        ExistingItemCheck(itemName);

        // If there is an item named "MAC & CHEESE", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }
        // If there is NOT an item named "MAC & CHEESE", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var macNCheese = ItemCreation(itemName, 10.39m, 1390, 0);

            // Add the macNCheese WawaItem object to a list.
            WawaItemsList.Add(macNCheese);
        }

        // Records the window session and adds it to a list/stack
        var sidesNsoupsMacAndCheeseSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(sidesNsoupsMacAndCheeseSession);

        startPrintOutSession();
    }

    // When the "Previous Button" image is clicked on, take the user to the previous screen.
    private void img_previousButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ScreenSessionRecord.previousButtonExecuted(WawaItemsList, ScreenSessionList, currentWindow);
    }

    // Searches for the list if the item is named after a certain item, like "CHICKEN NOODLE". Records the index it was located at.
    private void ExistingItemCheck(string ObjectName)
    {
        for (var i = 0; i < WawaItemsList.Count; i++)
            if (WawaItemsList[i].Name == ObjectName)
            {
                ItemIsInTheList = true;
                foundIndex = WawaItemsList.IndexOf(WawaItemsList[i]);
            }
    }

    // Creates an Item in the running list if it is not already there
    private WawaItem ItemCreation(string name, decimal price, int calories, int qty)
    {
        // Create a new Wawa Item object and set its properties based on the parsed fields.
        var objectName = new WawaItem
        {
            Name = name,
            Price = price,
            Calories = calories,
            QTY = qty + 1
        };
        return objectName;
    }

    // Create an object that records the details of the screen session
    private ScreenSessionRecord SessionCreation(string windowName, string itemName)
    {
        // Create a new session object and set its properties based on the parsed fields.
        var objectName = new ScreenSessionRecord
        {
            WindowName = windowName,
            ItemName = itemName
        };
        return objectName;
    }

    // Starts the session to the next window, which is the PrintOut Window
    private void startPrintOutSession()
    {
        var printOutWindowSession = new PrintOutWindow(WawaItemsList, ScreenSessionList);
        Close();
        printOutWindowSession.ShowDialog();
    }
}