using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

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
}