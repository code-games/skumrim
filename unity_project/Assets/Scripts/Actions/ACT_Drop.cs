using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Drop")]
public class ACT_Drop : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        //at least 1 arg required (item name)
        if (arguments.Length < 2) return;
        //ammount to be dropped, 1 by default
        int ammount = 1;
        string itemName = string.Empty;
        ItemStack istack = null;

        //do we have more than 1 argument?
        if (arguments.Length > 2)
        {
            //did the player set an ammount parameter?
            if (int.TryParse(arguments[arguments.Length - 1], out ammount))
            {
                if (ammount < 1)
                {
                    IOController.io.Log("Ammount to drop has to be positive");
                    return;
                }
                itemName = InputParseHelper.JoinArguments(arguments, end: -1);
            }
            else
            {
                ammount = 1;
                itemName = InputParseHelper.JoinArguments(arguments);
            }
        }
        else
        {
            itemName = arguments[1];
        }

        istack = Player.player.inventory.getItemWithName(itemName);

        if (istack != null)
        {
            if (istack.ammount < ammount)
            {
                if (istack.TakeAll()) IOController.io.Log("Item dropped");
            }
            else
            {
                if (istack.Take(ammount)) IOController.io.Log("Item dropped");
            }
        }
        else
        {
            IOController.io.Log("No such item in your inventory");
        }
    }
}
