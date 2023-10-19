using System;
using System.Collections.Generic;

public class Item
{
    private static int _itemCounter = 0;
    private List<Item> _allItems = new List<Item>();
    private int _idItem;
    private string _name;
    private Shelf _shelfOn;//The shelf on which the item is placed
    private string _itemType;//(food, drink)
    private string _kosherType;//(meat, dairy, parve)
    private DateTime _expiry;
    private double _space;

    public Item(string name, string itemType, string kosherType, DateTime expiry, double space)
    {
        _idItem = ++_itemCounter;
        _name = name;
        _shelfOn = null;//Not necessarily that the item goes into the fridge.
        _itemType = itemType;
        _kosherType = kosherType;
        _expiry = new DateTime(expiry.Year, expiry.Month, expiry.Day);
        _space = space;
        _allItems.Add(this);
    }
    public int IdItem
    {
        get { return _idItem; }

    }
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
        }
    }
    public Shelf ShelfOn
    {
        get { return _shelfOn; }
        set { _shelfOn = value; }
    }
    public string ItemType
    {
        get { return _itemType; }
    }
    public string KosherType
    {
        get { return _kosherType; }
    }
    public DateTime Expiry
    {
        get { return _expiry; }
        set
        {
            if (DateTime.Now > value)
                throw new ArgumentException("Invalid expiry date");
            _expiry = value;
        }
    }
    public double Space
    {
        get { return _space; }
    }
    public List<Item> AllItems
    {
        get { return _allItems; }
    }

    public override string ToString()
    {
        string printShelf = "The Item:\n\nid item: " + _idItem
            + "name: " + _name
            + "on shelf: " + _shelfOn.ToString()
            + "item type: " + _itemType
            + "kosher type: " + _kosherType
            + "expiry: " + _expiry.ToString()
            + "space: " + _space + "centimeter";
        return printShelf;
    }


}