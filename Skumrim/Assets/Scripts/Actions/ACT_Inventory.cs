//inventory
//  List all inventory items
//inventory[itemType]
//  List all inventory items of type[itemType]

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Inventory")]
public class ACT_Inventory : Action
{ 
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        //Do we have any arguments?
        if (arguments.Length < 2)
        {
            Player.player.inventory.Display();
        }
        else
        {
            string args = InputParseHelper.JoinArguments(arguments);

            switch (args)
            {
                case "basic":
                case "basics":
                    Player.player.inventory.DisplayItemsOfType(ItemType.Basic);
                    break;
                case "equipment":
                case "equipments":
                    Player.player.inventory.DisplayItemsOfType(ItemType.Equipment);
                    break;
                case "consumable":
                case "consumables":
                    Player.player.inventory.DisplayItemsOfType(ItemType.Consumable);
                    break;
                default:
                    IOController.io.LogError("No item type named '" + args + "'");
                    return;
            }
        }
    }
}
