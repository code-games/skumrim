using UnityEngine;

public class CharacterCreationMenu : GameModule
{
    /// <summary>
    /// we don't have a character creation yet so the new character option starts the game straight away for now
    /// </summary>
    public override void ActivateModule()
    {   
        //base.ActivateModule()

        GameManager.gameManager.StartGame();
    }
}
