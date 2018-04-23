using UnityEngine;

[CreateAssetMenu( menuName = "Skumrim/Actions/Quit" )]
public class ACT_Quit : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (Application.isEditor)
            IOController.io.LogSystem("Quitting game...");

        Application.Quit();
    }
}
