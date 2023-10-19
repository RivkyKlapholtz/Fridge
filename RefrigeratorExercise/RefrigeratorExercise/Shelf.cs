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
}