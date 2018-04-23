using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Shop")]
public class ACT_Shop : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (arguments.Length == 1)
        {
            IOController.io.Log("Syntax: shop [shopkeeper]");
            return;
        }

        string name = InputParseHelper.JoinArguments(arguments);

        NPC shop = GameManager.Navigation.currentLocation.getNPCByName(name);

        if (!shop)
        {
            IOController.io.Log("No shopkeeper named '" + name + "' here");
            return;
        }

        if (!shop.isShopkeeper)
        {
            IOController.io.Log(shop.name + " is not a shopkeeper");
            return;
        }

        ShopManager.shopManager.StartShop(shop.GetComponent<Inventory>());
    }
}
