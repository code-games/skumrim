using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Hunt")]
public class ACT_Hunt : Action
{
    GameTimeTimer timer;
    public int huntingDuration;

    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (timer == null) timer = new GameTimeTimer(huntingDuration, Hunting);

        if (!GameManager.Navigation.currentLocation.hasWildlife)
        {
            IOController.io.Log("There is no wildlife here");
            return;
        }

        IOController.io.readyToAct = false;
        IOController.io.Log("You start hunting...");

        timer.StartForcing();
    }

    public void Hunting()
    {
        IOController.io.Log("You finished hunting and found meat and hide");

        IOController.io.readyToAct = true;

        //get meat and hide
        Player.player.inventory.AddItem(ItemFactory.Basics.makeItem("Meat"));
        Player.player.inventory.AddItem(ItemFactory.Basics.makeItem("Hide"));
    }
}
