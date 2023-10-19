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
}