using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Lab_WawaApp;

/// <summary>
///     Interaction logic for HotBeveragesWindow.xaml
/// </summary>
public partial class HotBeveragesWindow : Window
{
    private readonly Window currentWindow;
    private readonly string currentWindowString = "HotBeveragesWindow";
    private readonly List<ScreenSessionRecord> ScreenSessionList = new();
    private readonly List<WawaItem> WawaItemsList = new();
    private int foundIndex;
    private bool ItemIsInTheList;
    private string itemName;

    public HotBeveragesWindow(List<WawaItem> wawaItemsList, List<ScreenSessionRecord> screenSessionRecords)
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

    // When this certain hot beverage (Double Shot of Espresso) image is clicked on, it adds its details to a list.
    // Takes it to the checkout/printout window as well.
    private void img_DoubleShotOfEspresso_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "DOUBLE SHOT OF ESPRESSO";

        // Checks to see if there is an existing object that is tied to the string "DOUBLE SHOT OF ESPRESSO"
        ExistingItemCheck(itemName);

        // If there is an item named "MOLTEN LAVA", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }
        // If there is NOT an item named "DOUBLE SHOT OF ESPRESSO", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var doubleShotOfEspresso = ItemCreation(itemName, 2.79m, 0, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(doubleShotOfEspresso);
        }

        // Records the window session and adds it to a list/stack
        var hotBeverageDDoESession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(hotBeverageDDoESession);

        startPrintOutSession();
    }

    // When this certain hot beverage (Molten Lava) image is clicked on, it adds its details to a list.
    // Takes it to the checkout/printout window as well.
    private void img_MoltenLava_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "MOLTEN LAVA";

        // Checks to see if there is an existing object that is tied to the string "MOLTEN LAVA"
        ExistingItemCheck(itemName);

        // If there is an item named "MOLTEN LAVA", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over. 
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }
        // If there is NOT an item named "MOLTEN LAVA", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var moltenLava = ItemCreation(itemName, 4.29m, 510, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(moltenLava);
        }

        // Records the window session and adds it to a list/stack
        var hotBeverageMoltenLavaSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(hotBeverageMoltenLavaSession);

        startPrintOutSession();
    }

    // When the "Previous Button" image is clicked on, take the user to the previous screen.
    private void img_previousButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ScreenSessionRecord.previousButtonExecuted(WawaItemsList, ScreenSessionList, currentWindow);
    }

    // Searches for the list if the item is named after a certain item, like "MOLTEN LAVA". Records the index it was located at.
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