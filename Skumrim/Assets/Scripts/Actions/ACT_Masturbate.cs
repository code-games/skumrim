using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Actions/Masturbate")]
public class ACT_Masturbate : Action
{
    GameTimeTimer timer;

    public override void Perform(string[] arguments)
    {
        base.Perform(arguments);

        if (timer == null) timer = new GameTimeTimer(8, Stop);

        IOController.io.LogLewd("You slip your hand under your pants and start masturbating");
        IOController.io.LogLewd("Unable to contain yourself any longer you start moaning");

        GameManager.Sound.PlaySoundByName("Moan");

        timer.StartForcing();
    }

    public void Stop()
    {
        GameManager.Sound.StopSoundByName("Moan");
        IOController.io.LogLewd("You stop masturbating");
    }
}
