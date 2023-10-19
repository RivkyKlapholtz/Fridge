using System;
using System.Collections.Generic;


public class Refrigerator
{
    private static int _refrigeratorCounter = 0;
    private List<Refrigerator> _allRefrigerators = new List<Refrigerator>();
    private int _idRefrigerator;
    private string _model;
    private string _color;
    private int _numberOfShelves;
    private List<Shelf> _shelves;

    public Refrigerator(string model, string color, int numberOfShelves)
    {
        _idRefrigerator = ++_refrigeratorCounter;
        _model = model;
        _color = color;
        _numberOfShelves = numberOfShelves;
        _shelves = new List<Shelf>();
        _allRefrigerators.Add(this);
    }

    public int IdRefrigerator
    {
        get { return _idRefrigerator; }
    }
    public string Model
    {
        get { return _model; }
        set{ _model = value; }
    }

    public string Color
    {
        get { return _color; }
        set{ _color = value; }
    }
    public double NumberOfShelves
    {
        get { return _numberOfShelves; }
    }

    public List<Shelf> Shelves
    {
        get { return _shelves; }
    }

    public List<Refrigerator> AllRefrigerators
    {
        get { return _allRefrigerators;}
    }

    public override string ToString()
    {
        string printRefrigerator = "The Refrigerator:\n\nid refrigerator: " + _idRefrigerator
            + "model: " + _model
            + "color: " + _color
            + "number of shelves: " + _numberOfShelves;
        foreach (Shelf shelf in _shelves)
        {
            printRefrigerator += shelf.ToString();
        }
        return printRefrigerator;

    }

    public void AddShelfToFridge(Shelf shelf)
    {
        if (_numberOfShelves == _shelves.Count)
        {
            throw new Exception("Not possible to add another shelf to this fridge");
        }
        _shelves.Add(shelf);
        shelf.AllShelves.Add(shelf);
    }

    public double CalculateSpaceLeftInFridge()
    {
        double spaceLeftInFridge = 0;

        foreach (Shelf shelf in _shelves)
        {
            spaceLeftInFridge += shelf.CalculateSpaceLeftInShelf();
        }
        return spaceLeftInFridge;
    }

    public void AddItemToFridge(Item item)
    {
        if (CalculateSpaceLeftInFridge() < item.Space)
        {
            throw new Exception("There is no space on the refrigerator whose ID is: " + _idRefrigerator + " for your item");
        }
        foreach (Shelf shelf in _shelves)
        {
            if (shelf.CalculateSpaceLeftInShelf() >= item.Space)
            {
                item.ShelfOn = shelf;
                shelf.AddItemToShelf(item);
            }
        }
    }

    public Item RemoveItemFromFridge(int idItemToRemove)
    {
        bool isExist = false;
        Item itemToRemove = null;
        foreach (Shelf shelf in _shelves)
        {
            if (shelf.ItemExistInShelf(idItemToRemove))
            {
                isExist = true;
                itemToRemove = shelf.RemoveItemFromShelf(idItemToRemove);
                itemToRemove.AllItems.Remove(itemToRemove);
                break;
            }
        }
        if (!isExist) { throw new Exception("The item is not in the refrigerator"); }
        return itemToRemove;
    }

    public void CleanRefrigerator()
    {
        foreach (Shelf shelf in _shelves)
        {
            shelf.CleanShelf();
        }
    }

    public List<Item> GetMatchingItemsInFridge(string itemType, string kosherType)
    {
        List<Item> itemsMatched = new List<Item>();
        if (ValidItemType(itemType) && ValidKosherType(kosherType))
        {
            List<Item> itemsInShelfMached = new List<Item>();
            foreach (Shelf shelf in _shelves)
            {
                itemsInShelfMached.Concat(shelf.GetMatchingItemsInShelf(itemType, kosherType));
                itemsMatched.Concat(itemsInShelfMached);
            }
        }
        else
        {
            throw new ArgumentException("Invalid input");
        }
        return itemsMatched;
    }

    public void PreparingForShopping()
    {
        if (CalculateSpaceLeftInFridge() >= 20)// *******************
        {
            Console.WriteLine("Your frigerator is ready for shopping!");
        }
        else
        {
            CleanRefrigerator();
            if (CalculateSpaceLeftInFridge() >= 20)
            {
                Console.WriteLine("Your frigerator is ready for shopping!");
            }
            else
            {
                double spaceWithout = 0;
                spaceWithout += CalculateSpaceLeftInFridgeWithout("Dairy", 3);
                if (CalculateSpaceLeftInFridge() >= 20)
                {
                    RemoveByKosherAndExpirationInFridge("Dairy", 3);
                    Console.WriteLine("Your frigerator is ready for shopping!");
                }
                else
                {
                    spaceWithout += CalculateSpaceLeftInFridgeWithout("Meat", 7);
                    if (CalculateSpaceLeftInFridge() >= 20)
                    {
                        RemoveByKosherAndExpirationInFridge("Meat", 7);
                        Console.WriteLine("Your frigerator is ready for shopping!");
                    }
                    else
                    {
                        spaceWithout += CalculateSpaceLeftInFridgeWithout("Parve", 1);
                        if (CalculateSpaceLeftInFridge() >= 20)
                        {
                            RemoveByKosherAndExpirationInFridge("Parve", 1);
                            Console.WriteLine("Your frigerator is ready for shopping!");
                        }
                        else
                        {
                            Console.WriteLine("It's not a good time for shopping");
                        }
                    }
                }
            }
        }
    }
    private bool ValidItemType(string itemType)
    {
        List<string> typs = new List<string>() { "Food", "Drink", "food", "drink"};

        return typs.Contains(itemType);
    }
    private bool ValidKosherType(string kosheType)
    {
        List<string> typs = new List<string>() { "meat", "dairy", "parve", "Meat", "Dairy", "Parve" };

        return typs.Contains(kosheType);
    }

    private double CalculateSpaceLeftInFridgeWithout(string kosherType, int beforNumberOfDays)
    {
        double spaceLeftInFridgeWithout = 0;
        foreach (Shelf shelf in _shelves)
        {
           spaceLeftInFridgeWithout += shelf.CalculateSpaceLeftInShelfWithout(kosherType, beforNumberOfDays);
        }
        return spaceLeftInFridgeWithout;
    }

    private void RemoveByKosherAndExpirationInFridge(string kosherType, int beforNumberOfDays)
    {
        foreach (Shelf shelf in _shelves)
        {
            shelf.RemoveByKosherAndExpirationInShelf(kosherType, beforNumberOfDays);
        }
    }
}