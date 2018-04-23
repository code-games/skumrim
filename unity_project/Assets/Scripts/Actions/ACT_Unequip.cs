using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Unequip")]
public class ACT_Unequip : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (arguments.Length == 1)
        {
            IOController.io.LogSystem("Syntax: unequip [slot]");
            return;
        }

        string args = InputParseHelper.JoinArguments(arguments);

        Player.player.equipments.Unequip(args);
    }
}
