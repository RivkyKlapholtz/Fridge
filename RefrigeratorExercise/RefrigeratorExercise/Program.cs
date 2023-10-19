using System;
using System.Collections.Generic;
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
        
    public List<Item> SortItemsByExpirationDate(List<Item> items)
    {
        return items.OrderBy(item => item.Expiry).ToList();
    }

    public List<Shelf> SortShelvesByFreeSpace(List<Shelf> shelves)
    {
        return shelves.OrderByDescending(shelf => shelf.CalculateSpaceLeftInShelf()).ToList();
    }
    public List<Refrigerator> SortRefrigeratorsByFreeSpace(List<Refrigerator> refrigerators)
    {
        return refrigerators.OrderByDescending(refrigerator => refrigerator.CalculateSpaceLeftInFridge()).ToList();
    }
    public void AddItem(Refrigerator fridge)
    {
        Console.WriteLine("Enter item details: (string name, string itemType, string kosherType, DateTime expiry, double space)");
        Item item = new Item(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine);
    }
       

}