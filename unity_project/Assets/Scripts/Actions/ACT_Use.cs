using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Use")]
public class ACT_Use : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (arguments.Length == 1)
        {
            IOController.io.Log("Syntax: use [item_name]");
            return;
        }

        string name = InputParseHelper.JoinArguments(arguments);

        ItemStack itemStack = grabItemIfExists(name);

        if (itemStack == null)
        {
            IOController.io.LogError("You have no item named '" + name + "'");
            return;
        }

        Item item = itemStack.item;

        if (item.Use() && item.getType() == ItemType.Consumable)
        {
            itemStack.TakeOne();
            IOController.io.LogSystem("1 '" + name + "' consumed");
        }
    }

    private ItemStack grabItemIfExists(string name)
    {
        return Player.player.inventory.getItemWithName(name);
    }
}
