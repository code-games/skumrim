using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    #region Singleton

    public static CraftingManager craftingManager;
    private void Awake()
    {
        craftingManager = this;
    }

    #endregion

    [HideInInspector]
    public List<Recipe> availableRecipes;

    private Recipe getRecipeForitemName(string name)
    {
        return availableRecipes.Find(r => r.product.item.name.ToLower() == name.ToLower());
    }

    public void StartCrafting(List<Recipe> recipes)
    {
        this.availableRecipes = recipes;

        this.ShowAvailableRecipes();

        IOController.io.grabExclusiveInput(CraftingCallback);
    }

    public void StopCrafting()
    {
        availableRecipes = null;
        IOController.io.releaseExclusiveInput(CraftingCallback);
    }

    public void ShowAvailableRecipes()
    {
        IOController.io.Log("Available Recipes:");

        foreach (Recipe recipe in availableRecipes)
        {
            recipe.ShowShort();
        }

        IOController.io.LogLine();
    }

    public void ShowRecipeForItemName(string itemName)
    {
        Recipe recipe = getRecipeForitemName(itemName);

        if (recipe != null)
        {
            recipe.Show();
        }
        else
        {
            IOController.io.Log("Recipe not available");
        }
    }

    public bool MakeItem(string[] arguments)
    {
        string itemName;
        int times;

        if (!InputParseHelper.ParseTextAndNumberArgs(arguments, out itemName, out times))
            return false;

        Recipe recipe = getRecipeForitemName(itemName);

        if (recipe == null)
            return false;

        return recipe.make(times);
    }

    public void ShowHelp()
    {
        IOController io = IOController.io;

        io.Log("recipes - list all available recipes");
        io.Log("show [item] - shows the recipe for that item, if available");
        io.Log("make [ammount] [item] - makes the specified ammount of the specified item");
        io.Log("inventory [arguments] - inventory action");
        io.Log("equipment [arguments] - equipment action");
        io.Log("quit - quits the crafting station");
    }

    public void CraftingCallback(string[] input)
    {
        string command = input[0];

        switch (command)
        {
            case "recipes":
                ShowAvailableRecipes();
                break;
            case "show":
                if (input.Length < 2)
                    break;
                ShowRecipeForItemName(InputParseHelper.JoinArguments(input));
                break;
            case "make":
                MakeItem(input);
                break;
            case "i":
            case "inventory":
            case "equipment":
            case "equipments":
            case "equip":
            case "equips":
                GameManager.Actions.PlayerActionInputCallback(input);
                break;
            case "quit":
                this.StopCrafting();
                break;
        }
    }
}
