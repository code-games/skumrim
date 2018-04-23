using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Crafting/Recipe")]
public class Recipe : ScriptableObject
{
    public List<RecipeItem> materials;
    public RecipeItem product;

    public bool playerHasMaterialsFor(int ammount = 1)
    {
        List<ItemStack> items = Player.player.inventory.getItems();
        ItemStack stack;

        foreach (RecipeItem ri in materials)
        {
            stack = items.Find(x => x.item.name == ri.item.name);

            if (stack == null || stack.ammount < ri.ammount)
                return false;
        }

        return true;
    }

    public bool make(int times)
    {
        List<ItemStack> items = Player.player.inventory.getItems();
        ItemStack stack;

        if (!this.playerHasMaterialsFor(times))
            return false;

        foreach (RecipeItem ri in materials)
        {
            stack = items.Find(x => x.item.name == ri.item.name);
            stack.Take(ri.ammount * times);
        }

        Player.player.inventory.AddItem(product.item, (product.ammount) * times);

        return true;
    }

    public int playerHasMaterialsToMakeHowMany()
    {
        List<ItemStack> items = Player.player.inventory.getItems();
        ItemStack stack;

        int ret = 9999;
        int times;

        foreach (RecipeItem ri in materials)
        {
            stack = items.Find(x => x.item.name == ri.item.name);

            if (stack == null || stack.ammount < ri.ammount)
                return 0;

            times = Mathf.FloorToInt(stack.ammount / ri.ammount);

            if (times < ret)
                ret = times;
        }

        return ret;
    }

    /// <summary>
    /// [how many times player can make] - [item name] x[number of items produced]
    /// </summary>
    public void ShowShort()
    {
        string line = playerHasMaterialsToMakeHowMany().ToString();

        line += " - " + product.item.name + " x" + product.ammount;

        IOController.io.Log(line);
    }

    /// <summary>
    /// [item name] x[ammount produced] \[[material1] x[ammount1],[material2] x[ammount2],...]
    /// You have material to make: x[how many times player can make]
    /// </summary>
    public void Show()
    {
        string line = product.item.name + " x" + product.ammount + " [";

        foreach (RecipeItem m in materials)
        {
            line += m.item.name + " x" + m.ammount  +  ", ";
        }

        line = line.Trim(new char[] {',', ' '});
        line += "]";

        IOController.io.Log(line);

        line = string.Empty;
        line = "You have material to make: x" + this.playerHasMaterialsToMakeHowMany();

        IOController.io.Log(line);
    }
}
