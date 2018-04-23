using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Properties

    public static GameManager gameManager;

    public static NavigationManager Navigation;
    public static ActionManager Actions;
    public static TimeManager GameTime;

    #endregion

    #region MonoBehaviour

    void Awake()
    {
        gameManager = this;

        Navigation = GetComponent<NavigationManager>();
        Actions = GetComponent<ActionManager>();
        GameTime = GetComponent<TimeManager>();
    }

    void OnDestroy()
    {
        this.GameClosing();
    }

    #endregion

    #region Methods

    /// <summary>
    /// This should be called by the MainMenu to start the game
    /// </summary>
    public void StartGame()
    {
        IOController.io.ClearLog();
        IOController.io.LogSystem("Welcome to Skumrim, " + Player.player.name + "!");
        IOController.io.LogSystem("Good Luck!");
        IOController.io.LogLine();
        Actions.ActivateModule();
        Navigation.StartGame();

        Player.player.Init();
    }

    public void GameClosing()
    {
        Actions.DeactivateModule();
    }

    #endregion
}
