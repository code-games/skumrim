using UnityEngine;

public class ActionManager : GameActionModule
{
    #region Properties

    private NavigationManager navigation;

    /// <summary>
    /// Actions that can be performed anywhere on the map
    /// </summary>
    public Action[] defaultActions;

    #endregion

    #region Methods

    public override void ActivateModule()
    {
        base.ActivateModule();

        navigation = GameManager.Navigation;
    }

    public override void PlayerActionInputCallback(string[] arguments)
    {
        if (!navigation.currentLocation.PerformActionWithArguments(arguments))
        {
            if (!this.PerformActionWithArguments(arguments))
            {
                IOController.io.Log(arguments[0] + " can't be performed here");
            }
        }
    }

    public bool PerformActionWithArguments(string[] arguments)
    {
        bool ret = false;
        string actionName = arguments[0];

        foreach (Action action in defaultActions)
        {
            if (action.isStringIdentifier(actionName))
            {
                action.Perform(arguments);
                ret = true;
                break;
            }
        }

        return ret;
    }

    #endregion
}
