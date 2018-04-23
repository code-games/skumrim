using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Interact")]
public class ACT_Interact : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (arguments.Length == 1)
        {
            IOController.io.Log("syntax: " + arguments[0] + " [interactable]");
            return;
        }

        string name = InputParseHelper.JoinArguments(arguments);

        InteractableObject inter = GameManager.Navigation.currentLocation.getInteractableByName(name);

        if(inter == null)
        {
            IOController.io.Log("No interactable named '" + name + "' here");
            return;
        }

        if (arguments[0] == "interact")
        {
            inter.Interact();
        }
        else
        {
            inter.Look();
        }
    }
}
