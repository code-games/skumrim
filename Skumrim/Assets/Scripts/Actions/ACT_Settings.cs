using UnityEngine;

[CreateAssetMenu( menuName = "Skumrim/Actions/Settings" )]
public class ACT_Settings : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (arguments.Length < 2)
        {
            this.listSettings();
            return;
        }

        string arg1 = arguments[1];

        switch (arg1)
        {
            case "volume":
                this.volume(arguments);
                break;
            default:
                IOController.io.LogError("No setting with the name \"" + arg1 + "\"");
                IOController.io.LogError("Type 'settings' to see the list of all the available game settings");
                break;
        }
    }

    private void listSettings()
    {
        IOController.io.LogSystem("Available settings:");
        IOController.io.LogSystem("volume [i]");
        IOController.io.LogLine();
    }

    private void volume(string[] arguments)
    {
        //did the player type a value after 'volume'?
        if (arguments.Length < 3)
        {
            IOController.io.LogError("Enter a number between 0-100 to set the volume");
            return;
        }

        //is the value an integer?
        int value;
        if (!int.TryParse(arguments[2], out value))
        {
            IOController.io.LogError("Enter a number between 0-100 to set the volume");
            return;
        }

        //is the value between 0 and a 100
        if (value < 0 || value > 100)
        {
            IOController.io.LogError("Enter a number between 0-100 to set the volume");
            return;
        }

        //then set the volume
        GameSettings.settings.volume = value;

        IOController.io.LogSystem("Volume set to " + value);
    }
}
