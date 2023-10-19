using System;

public class Shelf
{
    private static int _shelfCounter = 0;
    private List<Shelf> _allShelves = new List<Shelf>();
    private int _idShelf;
    private int _floorNumber;
    private double _originalSpace;
    private List<Item> _items;

    public Shelf(int floorNumber, double originalSpace)
    {
        _idShelf = ++_shelfCounter;
        _floorNumber = floorNumber;
        _originalSpace = originalSpace;
        _items = new List<Item>();
        _allShelves.Add(this);
    }

    public int IdShelf
    {
        get { return _idShelf; }
    }

    public int FloorNumber
    {
        get { return _floorNumber; }
    }

    public double OriginalSpace
    {
        get { return _originalSpace; }
    }
    public List<Item> Items
    {
        get { return _items; }
    }
    public List<Shelf> AllShelves
    {
        get { return _allShelves; }
    }

    public override string ToString()
    {
        string printShelf = "The Shelf:\n\nid shelf: " + _idShelf
            + "floor number: " + _floorNumber
            + "originalSpace: " + _originalSpace + " centimeter";
        foreach (Item item in _items)
        {
            printShelf += item.ToString();
        }
        return printShelf;
    }

    public double CalculateSpaceLeftInShelf()
    {
        double spaceLeftInShelf = _originalSpace;
        foreach (Item item in _items)
        {
            spaceLeftInShelf -= item.Space;
        }
        return spaceLeftInShelf;
    }

    public void AddItemToShelf(Item item)
    {
        _items.Add(item);
    }

    public bool ItemExistInShelf(int idItem)
    {
        foreach (Item item in _items)
        {
            if (item.IdItem == idItem) return true;
        }
        return false;
    }

    public Item RemoveItemFromShelf(int idItemToRemove)
    {
        Item itemToRemove = null;
        foreach(Item item in _items)
        {
            if (item.IdItem == idItemToRemove)
            {
                itemToRemove = item;
                _items.Remove(itemToRemove);
                break;
            }
        }
        return itemToRemove;
    }

    public void CleanShelf()
    {
        Item itemToRemove = null;
        foreach(Item item in _items)
        {
            if (item.Expiry < DateTime.Now)
            {
                itemToRemove = RemoveItemFromShelf(item.IdItem);
                item.AllItems.Remove(itemToRemove);
            }
        }
    }

    public List<Item> GetMatchingItemsInShelf(string itemType, string kosherType)
    {
        List<Item> itemsMached = new List<Item>();
        foreach (Item item in _items)
        {
            if (item.ItemType.Equals(itemType) && item.KosherType.Equals(kosherType) && (!item.isExpired()))
            {
                itemsMached.Add(item);
            }
        }
        return itemsMached;
    }

    public double CalculateSpaceLeftInShelfWithout(string kosherType, int beforNumberOfDays)
    {
        double spaceLeftInShelfWithout = CalculateSpaceLeftInShelf();
        foreach (Item item in _items)
        {
            if (item.KosherType.Equals(kosherType) &&
                item.Expiry < DateTime.Today.AddDays(beforNumberOfDays))
            {
                spaceLeftInShelfWithout += item.Space;
            }
        }
        return spaceLeftInShelfWithout;
    }

    public void RemoveByKosherAndExpirationInShelf(string kosherType, int beforNumberOfDays)
    {
        foreach (Item item in _items)
        {
            if (item.KosherType.Equals(kosherType) &&
                item.Expiry < DateTime.Today.AddDays(beforNumberOfDays))
            {
                Console.WriteLine("Remove valid item: \n" + item.ToString());
                _items.Remove(item);
                item.AllItems.Remove(item);
            }
        }
    }
}