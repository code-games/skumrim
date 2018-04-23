//equip/equip show
//  shows all equipment
//equip[slot]
//  shows item equipped at[slot]
//equip[item] (unimplemented)
//  equips[item] if possible(is not equipped, is in the inventory, is equipment)

using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Equipment")]
public class ACT_Equipment : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (arguments.Length == 1 || (arguments.Length == 2 && arguments[1] == "show"))
            Player.player.equipments.Show();
        else
        {
            if (arguments[1] == "show")
            {
                Player.player.equipments.ShowSlotWithName(arguments[2]);
            }
            else
            {
                string args = InputParseHelper.JoinArguments(arguments);

                ItemStack itemStack = Player.player.inventory.getItemWithName(args);

                if (itemStack == null)
                {
                    IOController.io.Log("'" + args + "': no such item in your inventory");
                    return;
                }

                if (itemStack.item.getType() != ItemType.Equipment)
                {
                    IOController.io.Log("'" + args + "': is not an equippable item");
                    return;
                }

                Item i = Player.player.equipments.Equip(itemStack.item as Equipment);

                if (i != null)
                    Player.player.inventory.AddItem(i);
            }
        }
    }
}
