using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Lockpick")]
public class ACT_Lockpick : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (arguments.Length < 2)
        {
            IOController.io.LogError("Use: lockpick [object]");
            return;
        }

        string name = InputParseHelper.JoinArguments(arguments);
        InteractableObject io = GameManager.Navigation.currentLocation.getInteractableByName(name);

        if (io == null)
        {
            IOController.io.Log("No such object at your current location");
            return;
        }

        if (io is LockableObject)
        {
            LockableObject lo = io as LockableObject;

            if (lo.locked)
            {
                //TODO: Check for lockpicks on the player's inventory
                //TODO: Skill check

                IOController.io.Log("The lock has been picked succesfully!");
                lo.Unlock();
                return;
            }
        }

        IOController.io.Log("The object '" + io.name + "' is not locked");
    }
}
