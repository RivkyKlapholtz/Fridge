﻿using System;
using System.Collections.Generic;

public class Item
{
    private static int _itemCounter = 0;
    private List<Item> _allItems = new List<Item>();
    private int _idItem;
    private string _name;
    private int _shelfOn;//id of the shelf on which the item is placed
    private string _itemType;//(food, drink)
    private string _kosherType;//(meat, dairy, parve)
    private DateTime _expiry;
    private double _space;

    public Item(string name, string itemType, string kosherType, DateTime expiry, double space)
    {
        _idItem = ++_itemCounter;
        _name = name;
        _shelfOn = -1;//Not necessarily that the item goes into the fridge.
        _itemType = itemType;
        _kosherType = kosherType;
        _expiry = new DateTime(expiry.Year, expiry.Month, expiry.Day);
        _space = space;
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
    public int ShelfOn
    {
        get { return _shelfOn; }
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


}