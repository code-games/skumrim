using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Clear")]
public class ACT_Clear : Action
{
    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        IOController.io.ClearLog();
    }
}
