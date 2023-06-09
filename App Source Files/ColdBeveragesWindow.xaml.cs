using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Lab_WawaApp;

/// <summary>
///     Interaction logic for ColdBeveragesWindow.xaml
/// </summary>
public partial class ColdBeveragesWindow : Window
{
    private readonly Window currentWindow;
    private readonly string currentWindowString = "ColdBeveragesWindow";
    private readonly List<ScreenSessionRecord> ScreenSessionList = new();
    private readonly List<WawaItem> WawaItemsList = new();
    private int foundIndex;
    private bool ItemIsInTheList;
    private string itemName;

    public ColdBeveragesWindow(List<WawaItem> wawaItemsList, List<ScreenSessionRecord> screenSessionRecords)
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

    // When this certain cold beverage (Lemonade) image is clicked on, it adds its details to a list.
    // Takes it to the checkout/printout window as well.
    private void img_Lemonade_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "LEMONADE";

        // Checks to see if there is an existing object that is tied to the string "LEMONADE"
        ExistingItemCheck(itemName);

        // If there is an item named "MOLTEN LAVA", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }

        // If there is NOT an item named "LEMONADE", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var lemonade = ItemCreation(itemName, 4.69m, 350, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(lemonade);
        }

        // Records the window session and adds it to a list/stack
        var coldBeverageLemonadeSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(coldBeverageLemonadeSession);

        startPrintOutSession();
    }

    // When this certain cold beverage (Green Tea) image is clicked on, it adds its details to a list.
    // Takes it to the checkout/printout window as well.
    private void img_GreenTea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "GREEN TEA";

        // Checks to see if there is an existing object that is tied to the string "GREEN TEA"
        ExistingItemCheck(itemName);

        // If there is an item named "GREEN TEA", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }

        // If there is NOT an item named "GREEN TEA", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var greenTea = ItemCreation(itemName, 4.29m, 10, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(greenTea);
        }

        // Records the window session and adds it to a list/stack
        var coldBeverageGreenTeaSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(coldBeverageGreenTeaSession);

        startPrintOutSession();
    }

    // When this certain cold beverage (Chai Matcha) image is clicked on, it adds its details to a list.
    // Takes it to the checkout/printout window as well.
    private void img_ChaiMatcha_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "CHAI MATCHA";

        // Checks to see if there is an existing object that is tied to the string "CHAI MATCHA"
        ExistingItemCheck(itemName);

        // If there is an item named "CHAI MATCHA", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }

        // If there is NOT an item named "CHAI MATCHA", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var chaiMatcha = ItemCreation("CHAI MATCHA", 4.79m, 290, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(chaiMatcha);
        }

        // Records the window session and adds it to a list/stack
        var coldBeverageChaiMatchaSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(coldBeverageChaiMatchaSession);

        startPrintOutSession();
    }

    // When the "Previous Button" image is clicked on, take the user to the previous screen.
    private void img_previousButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ScreenSessionRecord.previousButtonExecuted(WawaItemsList, ScreenSessionList, currentWindow);
    }

    // Searches for the list if the item is named after a certain item, like "LEMONADE". Records the index it was located at.
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