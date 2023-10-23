# Fridge

Fridge is a program that enables operations on refrigerator inventory.

## Table of Contents

- [Introduction](#introduction)
- [Classes](#classes)
  - [Item.cs](#itemcs)
  - [Shelf.cs](#shelfcs)
  - [Refrigerator.cs](#refrigeratorcs)
  - [Program.cs](#programcs)

## Introduction

The Fridge program is designed to help you manage your refrigerator inventory efficiently. It consists of three primary classes: `Item.cs`, `Shelf.cs`, and `Refrigerator.cs`, each responsible for different aspects of your refrigerator inventory management.

## Classes

### Item.cs

The `Item.cs` class is responsible for managing individual items within the refrigerator inventory. It contains various methods and properties to handle items. Here are some of the methods within the `Item.cs` class:

- `ToString()` - Returns a string that clearly represents the item.
- `isExpired()` - Returns whether a product is expired or not.



Example usage:

```csharp
// Create an instance of the Item class
item = new Item(itemName, itemType, itemKosher, itemExpiry, itemSpace);
```


### Shelf.cs

The `Shelf.cs` class is responsible for managing individual items within the refrigerator inventory. It contains various methods and properties to handle items. Here are some of the methods within the `Shelf.cs` class:

- `CalculateSpaceLeftInShelf()` - Returns a double value that represents how much free space in centimeters remains on the shelf.
- `AddItemToShelf(Item item)` - Adds an item to the shelf.
- `ItemExistInShelf(int idItem)` - Returns whether a product is xists on the shelf or not.
- `RemoveItemFromShelf(int idItemToRemove)` - Deletes a specific item from the shelf.
- `CleanShelf()` - All expired items are deleted.
- `GetMatchingItemsInShelf(string itemType, string kosherType)` - Returns a list of items on the shelf that match the requirements received in the function.

Example usage:

```csharp
// Create an instance of the Item class
Shelf shelf2 = new Shelf(2, 30);
//Add an Item to the shelf
shelf.AddItemToShelf(item);
```

### Refrigerator.cs

The `Refrigerator.cs` class is responsible for managing individual items within the refrigerator inventory. It contains various methods and properties to handle items. Here are some of the methods within the `Refrigerator.cs` class:

- `CalculateSpaceLeftInFridge()` - Returns a double value that represents how much free space in centimeters remains on the refrigerator.
- `AddItemToShelf(Item item)` - Returns whether a product is expired or not.
- `AddItemToFridge(Item item)` - Adds an Item to the refrigerator.
- `RemoveItemFromFridge(int idItemToRemove)` - Removes an Item from the refrigerator.
- `CleanRefrigerator()` - All expired items are deleted.
- `GetMatchingItemsInFridge(string itemType, string kosherType)` - Returns a list of items on the shelf that match the requirements received in the function.
- `PreparingForShopping()` - Prepares the fridge for shopping in terms of free space.

Example usage:

```csharp
// Create an instance of the Refrigerator class
Refrigerator refrigerator1 = new Refrigerator("My Fridge", "White", 3);
```
## What does the program offer in terms of user interface?
The Program.cs class prints 10 options for the user that he can choose, all options are actions on the refrigerator or its contents.

**Below are some screenshots that show what the user sees when running the program:**

![image](https://github.com/RivkyKlapholtz/Fridge/assets/129298796/eaf39d32-690b-40c6-8ac8-e30474fb5c8f)




# 😁😁 Have fun with your fridge 😁😁


