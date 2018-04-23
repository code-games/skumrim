using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager shopManager;

    public Inventory shopInventory;

    private ItemStack buyingStack;
    private ItemStack sellingStack;

    private void Awake()
    {
        shopManager = this;
    }

    public void StartShop(Inventory shopInventory)
    {
        this.shopInventory = shopInventory;

        IOController.io.grabExclusiveInput(ShopCallback);

        DisplayShop();
    }

    public void StopShop()
    {
        shopInventory = null;
        IOController.io.releaseExclusiveInput(ShopCallback);
    }

    public void DisplayShop()
    {
        IOController.io.Log("Shop:");
        shopInventory.Display();
    }

    private void buy(string input)
    {
        if (input.Length == 0)
            return;

        ItemStack stack = shopInventory.getItemWithName(input);

        if (stack == null)
        {
            IOController.io.Log("The shop doesn't have what you're looking for");
            DisplayShop();
            return;
        }

        buyingStack = stack;
        stack.Show();
        IOController.io.Log("How many would you like to buy?");
        IOController.io.grabNextInput(BuyAmmountCallback);
    }

    public void BuyAmmountCallback(string input)
    {
        int ammount;
        ItemStack stack = buyingStack;
        buyingStack = null;

        if (int.TryParse(input, out ammount))
        {
            if (stack.ammount < ammount)
                ammount = stack.ammount;

            int cost = stack.item.baseValue * ammount;

            if (Player.player.inventory.gold < cost)
            {
                IOController.io.Log("Not enough money");
            }
            else
            {
                stack.Take(ammount);
                Player.player.inventory.AddItem(stack.item, ammount);
                shopInventory.AddGold(cost);
                Player.player.inventory.RemoveGold(cost);
                
            }
        }

        DisplayShop();
    }

    private void sell(string input)
    {
        if (input.Length == 0)
            return;

        ItemStack stack = Player.player.inventory.getItemWithName(input);

        if (stack == null)
        {
            IOController.io.Log("You don't have the item you want to sell on your inventory");
            DisplayShop();
            return;
        }

        sellingStack = stack;
        stack.Show();
        IOController.io.Log("How many would you like to sell?");
        IOController.io.grabNextInput(SellAmmountCallback);
    }

    public void SellAmmountCallback(string input)
    {
        int ammount;
        ItemStack stack = sellingStack;
        sellingStack = null;

        if (int.TryParse(input, out ammount))
        {
            if (stack.ammount < ammount)
                ammount = stack.ammount;

            int cost = stack.item.baseValue * ammount;

            if (shopInventory.gold < cost)
            {
                IOController.io.Log("The shopkeeper doesn't have enough money");
            }
            else
            {
                stack.Take(ammount);
                shopInventory.AddItem(stack.item, ammount);
                shopInventory.RemoveGold(cost);
                Player.player.inventory.AddGold(cost);
            }
        }

        DisplayShop();
    }

    public void ShopCallback(string[] input)
    {
        switch(input[0])
        {
            case "inventory":
            case "equip":
            case "equips":
            case "equipment":
                GameManager.Actions.PerformActionWithArguments(input);
                break;
            case "buy":
            case "b":
                buy(InputParseHelper.JoinArguments(input));
                return;
            case "sell":
            case "s":
                sell(InputParseHelper.JoinArguments(input));
                return;
            case "quit":
                this.StopShop();
                return;
        }

        DisplayShop();
    }
}
