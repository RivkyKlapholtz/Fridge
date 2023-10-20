using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Refrigerator refrigerator1 = new Refrigerator("My Fridge", "White", 3);
        Refrigerator refrigerator2 = new Refrigerator("My Fridge", "red", 4);
        Refrigerator refrigerator3 = new Refrigerator("My Fridge", "black", 4);
        Refrigerator refrigerator4 = new Refrigerator("My Fridge", "gray", 6);
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Print all items in the refrigerator");
            Console.WriteLine("2: Print available space in the fridge");
            Console.WriteLine("3: Add an item to the refrigerator");
            Console.WriteLine("4: Remove an item from the refrigerator");
            Console.WriteLine("5: Clean the refrigerator and print removed items");
            Console.WriteLine("6: Check what you want to eat and retrieve the product");
            Console.WriteLine("7: Print all products sorted by expiration date");
            Console.WriteLine("8: Print all shelves sorted by free space");
            Console.WriteLine("9: Print all refrigerators sorted by free space");
            Console.WriteLine("10: Prepare the refrigerator for shopping");
            Console.WriteLine("100: Close the system");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(refrigerator1.ToString());
                        break;
                    case 2:
                        Console.WriteLine(refrigerator1.CalculateSpaceLeftInFridge());
                        break;
                    case 3:
                        AddItem(refrigerator1);
                        break;
                    case 4:
                        RemoveItemFromRefrigerator(refrigerator1);
                        break;
                    case 5: 
                        Console.WriteLine("Checked items: " + refrigerator1.CleanRefrigerator());
                        break; 
                    case 6:
                        WhatToEat(refrigerator1);
                        break;
                    case 7:
                        SortItem(refrigerator1);
                        break;
                    case 8:
                        SortShelf(refrigerator1);
                        break;
                    case 9:
                        SortRefrigerator(refrigerator1);
                        break;
                    case 10:
                        refrigerator1.PreparingForShopping();
                        break;
                    case 100:
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

        }
    }
        
    public static List<Item> SortItemsByExpirationDate(List<Item> items)
    {
        return items.OrderBy(item => item.Expiry).ToList();
    }

    public static List<Shelf> SortShelvesByFreeSpace(List<Shelf> shelves)
    {
        return shelves.OrderByDescending(shelf => shelf.CalculateSpaceLeftInShelf()).ToList();
    }
    public static List<Refrigerator> SortRefrigeratorsByFreeSpace(List<Refrigerator> refrigerators)
    {
        return refrigerators.OrderByDescending(refrigerator => refrigerator.CalculateSpaceLeftInFridge()).ToList();
    }
    private static void AddItem(Refrigerator refrigerator)
    {
        Item item = null;

        Console.WriteLine("Enter the ItemName");
        string itemName = Console.ReadLine();
        Console.WriteLine("Enter the ItemSpace");
        double itemSpace;

        if (double.TryParse(Console.ReadLine(), out itemSpace))
        {
            Console.WriteLine("Enter the ItemExpiryDate (yyyy-MM-dd)");
            string itemExpiryDate = Console.ReadLine();
            Console.WriteLine("Enter the Kosher (Parve, Dairy, Meat)");
            string itemKosher = Console.ReadLine();
            Console.WriteLine("Enter the ItemType (Food, Drink)");
            string itemType = Console.ReadLine();

            if (ValidInputName(itemName) &&
                refrigerator.ValidItemType(itemType) &&
                refrigerator.ValidKosherType(itemKosher) &&
                ValidInputExity(itemExpiryDate))
            {
                DateTime itemExpiry = DateTime.Parse(itemExpiryDate);
                item = new Item(itemName, itemType, itemKosher, itemExpiry, itemSpace);
                Console.WriteLine("Item created successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please check your input and try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid item space. Please enter a valid number.");
        }
        if(item == null) { Console.WriteLine("Failed to add the item to the refrigerator."); }
        else { refrigerator.AddItemToFridge(item); }
    }

    private static void RemoveItemFromRefrigerator(Refrigerator refrigerator)
    {
        Console.WriteLine("Enter the item ID to remove from the refrigerator:");
        int itemId = Convert.ToInt32(Console.ReadLine());
        Item removedItem = null;
        try
        {
            removedItem = refrigerator.RemoveItemFromFridge(itemId);
        }
        catch (Exception e) { Console.WriteLine("The item is not in the refrigerator"); }

        if (removedItem != null)
        {
            Console.WriteLine($"Item removed: {removedItem.ToString()}");
        }
    }

    public static bool ValidInputName(string itemName)
    {
        return (string.IsNullOrWhiteSpace(itemName));

    }

    public static bool ValidInputExity(string itemExpiryDate)
    {
        return (DateTime.TryParseExact(itemExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _));
    }


    public static void WhatToEat(Refrigerator refrigerator)
    {
        Console.WriteLine("What do you want to eat?");
        Console.WriteLine("Please enter a item type and a kosher type:");
        string itemType = Console.ReadLine();
        string kosherType = Console.ReadLine();
        if (!(refrigerator.ValidItemType(itemType) && refrigerator.ValidKosherType(kosherType))) 
        {
            Console.WriteLine("Invalid input");
        }
        else
        {
            List<Item> itemsMached = refrigerator.GetMatchingItemsInFridge(itemType, kosherType);
            foreach (Item item in itemsMached) { Console.WriteLine(item.ToString()); }
        }
    }

    public static void SortItem(Refrigerator refrigerator)
    {
        List<Item> items = new List<Item>();
        foreach (Shelf shelf in refrigerator.Shelves)
        {
            items.Concat(shelf.Items);
        }
        List<Item> sortedItems = SortItemsByExpirationDate(items);
        foreach (Item item in sortedItems)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public static void SortShelf(Refrigerator refrigerator)
    {
        List<Shelf> sortedShelves = SortShelvesByFreeSpace(refrigerator.Shelves);
        foreach (Shelf shelf in sortedShelves)
        {
            Console.WriteLine(shelf.ToString());
        }
    }

    public static void SortRefrigerator(Refrigerator refrigerator)
    {
        List<Refrigerator> sortedRefrigerators = SortRefrigeratorsByFreeSpace(refrigerator.AllRefrigerators);
        foreach (Refrigerator fridge in sortedRefrigerators)
        {
            Console.WriteLine(fridge.ToString());
        }
    }


}