using System.Collections.Generic;
using System.Windows;

namespace Lab_WawaApp;

public class ScreenSessionRecord
{
    public string WindowName { get; set; }
    public string ItemName { get; set; }

    public static void previousButtonExecuted(List<WawaItem> wawaItemsList,
        List<ScreenSessionRecord> screenSessionRecords, Window currentWindow)
    {
        var WawaItemsList = wawaItemsList;
        var ScreenSessionList = screenSessionRecords;

        // Saves the latest session as an object and deletes it from the list
        var lastItem = ScreenSessionList[ScreenSessionList.Count - 1];
        ScreenSessionList.RemoveAt(ScreenSessionList.Count - 1);

        // If the previous window was the "StartingWindow" window (Window is currently at the "SelectionMenu" window)
        if (lastItem.WindowName == "StartingWindow")
        {
            var newWindowSession = new MainWindow();
            currentWindow.Close();
            newWindowSession.ShowDialog();
        }
        // If the previous window was the "SelectionMenu" window (Window is currently at the "HoagiesWindow"/"SoupAndSidesWindow"/"HotAndColdBeverage" window)
        else if (lastItem.WindowName == "SelectionMenu")
        {
            var newWindowSession = new SelectionMenu(ScreenSessionList);
            currentWindow.Close();
            newWindowSession.ShowDialog();
        }
        // If the previous window was the "HoagieWindow" window (Window is currently at the "PrintOut" window)
        else if (lastItem.WindowName == "HoagieWindow")
        {
            // First, find out where this item is in the WawaItem list (it has to exist since the session object recorded what option we interacted with)
            var foundIndex = FindItemIndex(lastItem.ItemName, WawaItemsList);

            // Second, figure out if the item has more than one quantity to it (in other words, was it the first time it was added to the running list?)
            WawaItemsList = FirstTimeItemCheck(WawaItemsList, foundIndex);

            // Start the new "HoagieWindow" window session
            var newWindowSession = new HoagieWindow(WawaItemsList, ScreenSessionList);
            currentWindow.Close();
            newWindowSession.ShowDialog();
        }
        // If the previous window was the "PrintOutWindow" window (Window is currently at the "HoagiesWindow"/"SoupAndSidesWindow"/"HotAndColdBeverage" window)
        else if (lastItem.WindowName == "PrintOutWindow")
        {
            var newWindowSession = new PrintOutWindow(wawaItemsList, ScreenSessionList);
            currentWindow.Close();
            newWindowSession.ShowDialog();
        }

        // If the previous window was the "SoupsAndSidesWindow" window (Window is currently at the "PrintOut" window)
        else if (lastItem.WindowName == "SoupsAndSidesWindow")
        {
            // First, find out where this item is in the WawaItem list (it has to exist since the session object recorded what option we interacted with)
            var foundIndex = FindItemIndex(lastItem.ItemName, WawaItemsList);

            // Second, figure out if the item has more than one quantity to it (in other words, was it the first time it was added to the running list?)
            WawaItemsList = FirstTimeItemCheck(WawaItemsList, foundIndex);

            // Start the new "HoagieWindow" window session
            var newWindowSession = new SoupsAndSidesWindow(WawaItemsList, ScreenSessionList);
            currentWindow.Close();
            newWindowSession.ShowDialog();
        }

        // If the previous window was the "HotAndColdBeverageWindow" window (Window is currently at the "ColdBeveragesWindow"/"HotBeveragesWindow" window)
        else if (lastItem.WindowName == "HotAndColdBeverageWindow")
        {
            var newWindowSession = new HotAndColdBeverageWindow(wawaItemsList, ScreenSessionList);
            currentWindow.Close();
            newWindowSession.ShowDialog();
        }

        // If the previous window was the "ColdBeveragesWindow" window (Window is currently at the "PrintOut" window)
        else if (lastItem.WindowName == "ColdBeveragesWindow")
        {
            // First, find out where this item is in the WawaItem list (it has to exist since the session object recorded what option we interacted with)
            var foundIndex = FindItemIndex(lastItem.ItemName, WawaItemsList);

            // Second, figure out if the item has more than one quantity to it (in other words, was it the first time it was added to the running list?)
            WawaItemsList = FirstTimeItemCheck(WawaItemsList, foundIndex);

            // Start the new "HoagieWindow" window session
            var newWindowSession = new ColdBeveragesWindow(WawaItemsList, ScreenSessionList);
            currentWindow.Close();
            newWindowSession.ShowDialog();
        }

        // If the previous window was the "ColdBeveragesWindow" window (Window is currently at the "PrintOut" window)
        else if (lastItem.WindowName == "HotBeveragesWindow")
        {
            // First, find out where this item is in the WawaItem list (it has to exist since the session object recorded what option we interacted with)
            var foundIndex = FindItemIndex(lastItem.ItemName, WawaItemsList);

            // Second, figure out if the item has more than one quantity to it (in other words, was it the first time it was added to the running list?)
            WawaItemsList = FirstTimeItemCheck(WawaItemsList, foundIndex);

            // Start the new "HoagieWindow" window session
            var newWindowSession = new HotBeveragesWindow(WawaItemsList, ScreenSessionList);
            currentWindow.Close();
            newWindowSession.ShowDialog();
        }
    }

    // Searches the WawaItem list to determine where the item name that was recorded by the last session was located at
    private static int FindItemIndex(string ObjectName, List<WawaItem> WawaItemsList)
    {
        var foundIndex = 0;
        for (var i = 0; i < WawaItemsList.Count; i++)
            if (WawaItemsList[i].Name == ObjectName)
                foundIndex = WawaItemsList.IndexOf(WawaItemsList[i]);
        return foundIndex;
    }

    // Checks to see if there is more than one item of a certain option. If not, remove it from the list entirely.
    private static List<WawaItem> FirstTimeItemCheck(List<WawaItem> WawaItemsList, int foundIndex)
    {
        if (WawaItemsList[foundIndex].QTY > 1)
            WawaItemsList[foundIndex].QTY = WawaItemsList[foundIndex].QTY - 1;
        else
            WawaItemsList.RemoveAt(foundIndex);
        return WawaItemsList;
    }
}