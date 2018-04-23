using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Look")]
public class ACT_Look : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (arguments.Length == 1)
            GameManager.Navigation.currentLocation.Describe();
        else
            LookAt(InputParseHelper.JoinArguments(arguments));
    }

    private void LookAt(string exitName)
    {
        Place p = GameManager.Navigation.currentLocation.getExitByName(exitName);

        if (p == null)
        {
            IOController.io.LogError("No such exit '" + exitName + "' at this place");
        }
        else
        {
            IOController.io.Log("You see " + p.name);
        }
    }
}
