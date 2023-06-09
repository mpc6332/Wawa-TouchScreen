﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Lab_WawaApp;

/// <summary>
///     Interaction logic for HoagieWindow.xaml
/// </summary>
public partial class HoagieWindow : Window
{
    private readonly Window currentWindow;
    private readonly List<ScreenSessionRecord> ScreenSessionList = new();
    private readonly List<WawaItem> WawaItemsList = new();
    private readonly string currentWindowString = "HoagieWindow";
    private int foundIndex;
    private bool ItemIsInTheList;
    private string itemName;

    public HoagieWindow(List<WawaItem> wawaItemsList, List<ScreenSessionRecord> screenSessionList)
    {
        InitializeComponent();
        WawaItemsList = wawaItemsList;
        ScreenSessionList = screenSessionList;
        currentWindow = GetWindow(this);
    }

    // When the Textbox is loaded, list all of the elements that are stored in the WawaItemsList
    private void txt_MyOrderList_Loaded(object sender, RoutedEventArgs e)
    {
        for (var i = 0; i < WawaItemsList.Count; i++) txt_MyOrderList.Text += WawaItemsList[i] + "\n\n\n";
    }

    // When this option (Chicken cheesesteak) image is clicked on, it adds its details to a list.
    // Takes it to the checkout/printout window as well.
    private void img_cheesesteakHoagie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "CHICKEN CHEESESTEAK";

        // Checks to see if there is an existing object that is tied to the string "CHICKEN CHEESESTEAK"
        ExistingItemCheck(itemName);

        // If there is an item named "CHICKEN CHEESESTEAK", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }
        // If there is NOT an item named "CHICKEN CHEESESTEAK", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var chickenCheeseSteak = ItemCreation(itemName, 4.39m, 360, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(chickenCheeseSteak);
        }

        // Records the window session and adds it to a list/stack
        var hoagieMenuChickenCheesesteakSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(hoagieMenuChickenCheesesteakSession);

        startPrintOutSession();
    }

    // When this certain hoagie (Meatball) image is clicked on, it adds its details to a list.
    // Takes it to the checkout/printout window as well.
    private void img_meatballHoagie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "MEATBALL";

        // Checks to see if there is an existing object that is tied to the string "MEATBALL"
        ExistingItemCheck(itemName);

        // If there is an item named "MEATBALL", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }

        // If there is NOT an item named "MEATBALL", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var meatBall = ItemCreation(itemName, 6.59m, 1360, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(meatBall);
        }

        // Records the window session and adds it to a list/stack
        var hoagieMenuMeatballSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(hoagieMenuMeatballSession);

        startPrintOutSession();
    }

    // When this certain hoagie (Roast beef) image is clicked on, it adds its details to a list.
    // Takes it to te checkout window as well.
    private void img_roastbeefHoagie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        itemName = "ROAST BEEF";

        // Checks to see if there is an existing object that is tied to the string "MEATBALL"
        ExistingItemCheck(itemName);

        // If there is an item named "ROAST BEEF"", this means that the user is adding to update the quantity of it. In this case, just increase its quantity by 1 over.
        if (ItemIsInTheList)
        {
            WawaItemsList[foundIndex].QTY += 1;
        }

        // If there is NOT an item named "ROAST BEEF"", create the object for it and add it to the running list.
        else if (ItemIsInTheList == false)
        {
            var roastBeef = ItemCreation(itemName, 8.89m, 770, 0);

            // Add the chickenNoodle WawaItem object to a list.
            WawaItemsList.Add(roastBeef);
        }

        // Records the window session and adds it to a list/stack
        var hoagieMenuRoastBeefSession = SessionCreation(currentWindowString, itemName);
        ScreenSessionList.Add(hoagieMenuRoastBeefSession);

        startPrintOutSession();
    }

    // When the "Previous Button" image is clicked on, take the user to the previous screen.
    private void img_previousButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ScreenSessionRecord.previousButtonExecuted(WawaItemsList, ScreenSessionList, currentWindow);
    }

    // Searches for the list if the item is named after a certain item, like "ROAST BEEF". Records the index it was located at.
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