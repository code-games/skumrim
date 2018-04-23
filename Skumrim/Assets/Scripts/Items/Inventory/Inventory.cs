#pragma warning disable 0414

using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Unit owner;
    private EquipController equips;

    private int encumbrance;
    private int carryingCapacity;

    private List<ItemStack> items;
    public int gold { get; protected set; }

    public StartingInventory startingInventory;

    private void loadStartingItems()
    {
        foreach (StartingItem i in startingInventory.items)
        {
            items.Add(this.getNewItemStackForItemAndAmmount(Instantiate(i.item), i.ammount));
        }

        this.gold = startingInventory.gold;
    }

    private void Awake()
    {
        owner = GetComponent<Unit>();
        equips = GetComponent<EquipController>();

        encumbrance = 0;
        if(owner)
            carryingCapacity = owner.stats.carryingCapacity;

        items = new List<ItemStack>();

        loadStartingItems();
    }

    public ItemStack getNewItemStackForItemAndAmmount(Item item, int ammount)
    {
        if (item == null) return null;

        return new ItemStack(this, item, ammount);
    }

    public ItemStack getNewItemStackForItem(Item item)
    {
        if (item == null) return null;
        return this.getNewItemStackForItemAndAmmount(item, 1);
    }

    public ItemStack getItemWithName(string itemName)
    {
        if (string.IsNullOrEmpty(itemName)) return null;

        foreach (ItemStack itemStack in items)
        {
            if (itemStack.item.name.ToLower() == itemName.ToLower())
                return itemStack;
        }

        return null;
    }

    public List<ItemStack> getItems()
    {
        return items;
    }

    public List<ItemStack> getItemsOfType(ItemType type)
    {
        List<ItemStack> ret = new List<ItemStack>();

        foreach (ItemStack itemStack in items)
        {
            if (itemStack.item.getType() == type)
                ret.Add(itemStack);
        }

        return ret;
    }

    public void AddItems(ItemStack[] items)
    {
        if (items == null) return;

        foreach (ItemStack itemStack in items)
        {
            this.AddItem(itemStack);
        }
    }

    public void AddItems(Item[] items)
    {
        if (items == null) return;

        foreach (Item item in items)
        {
            this.AddItem(item);
        }
    }

    public void AddItem(ItemStack itemStack)
    {
        if (itemStack == null || itemStack.ammount == 0) return;

        ItemStack existingStack = getItemWithName(itemStack.item.name);

        if (existingStack != null)
        {
            existingStack.Add(itemStack.ammount);
        }
        else
        {
            items.Add(itemStack);
        }
    }

    public void AddItem(Item item, int ammount)
    {
        if (item == null || ammount == 0) return;

        this.AddItem(this.getNewItemStackForItemAndAmmount(item, ammount));
    }

    public void AddItem(Item item)
    {
        if (item == null) return;

        this.AddItem(this.getNewItemStackForItem(item));
    }

    public void AddGold(int ammount)
    {
        gold += ammount;
    }

    public bool RemoveGold(int ammount)
    {
        if (gold < ammount)
            return false;

        gold -= ammount;
        return true;
    }

    public void RemoveAllGold()
    {
        gold = 0;
    }

    public void ClearStack(ItemStack itemStack)
    {
        items.Remove(itemStack);
    }

    public void Display()
    {

        if (items.Count == 0)
        {
            IOController.io.Log("Empty");
        }
        else
        {
            foreach (ItemStack i in items)
            {
                i.Show();
            }
        }

        ShowGold();
    }

    public void DisplayItemsOfType(ItemType type)
    {
        List<ItemStack> l = getItemsOfType(type);

        if (l.Count == 0)
        {
            IOController.io.Log("No items found");
        }
        else
        {
            foreach (ItemStack item in l)
            {
                item.Show();
            }
        }

        ShowGold();
    }

    public void ShowGold()
    {
        IOController.io.Log("Gold: " + gold);
    }
}
