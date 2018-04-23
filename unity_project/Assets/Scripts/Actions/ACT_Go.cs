using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Go")]
public class ACT_Go : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        string moveto = string.Empty;
        Place currentLocation = GameManager.Navigation.currentLocation;
        Place place = null;

        if (arguments.Length == 1)
        {
            moveto = arguments[0];
        }
        else
        {
            moveto = InputParseHelper.JoinArguments(arguments);
        }

        place = currentLocation.getExitByName(moveto);

        if (place == null)
        {
            IOController.io.LogError("No such exit '" + moveto + "' at this place");
        }
        else
        {
            IOController.io.Log("Walking...");
            GameManager.Navigation.MoveToPlaceWithDelay(place, .5f);
        }
    }
}
