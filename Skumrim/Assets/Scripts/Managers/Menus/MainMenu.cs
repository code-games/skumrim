using UnityEngine;

public class MainMenu : GameModule
{
    public static MainMenu mainMenu;

    private IOController io;

    private CharacterCreationMenu characterCreation;

    private void Awake()
    {
        mainMenu = this;

        characterCreation = GetComponent<CharacterCreationMenu>();
    }

    private void Start()
    {
        io = IOController.io;
        this.ActivateModule();
    }

    private void loadCharacterCreation()
    {
        this.DeactivateModule();
        characterCreation.ActivateModule();
    }

    private void loadSkinMenu()
    {
        UISkinController.skinController.ListAvailableSkins();

        IOController.io.grabNextInput(skinInputCallback);
    }

    public void skinInputCallback(string input)
    {
        UISkinController.skinController.SetSkinByName(input);
        printMenu();
    }

    private void QuitGame()
    {
        if (Application.isEditor)
            io.Log("Quitting game");

        Application.Quit();
    }

    private void printMenu()
    {
        io.ClearLog();

        io.LogAccent("the Pervert Scrolls: Skumrim");
        io.LogLewd("R-Rated text-based fantasy rpg");
        io.LogLine();
        io.LogSystem("Heavily based on The Elder Scrolls: Skyrim");
        io.LogSystem("Inspired on MUDs");
        io.LogSystem("Made by: Aspire Inc.");
        io.LogLine();
        io.Log("Main Menu:");
        io.Log("[N]ew Character");
        io.Log("Change UI [S]kin");
        io.Log("[Q]uit");
        io.Log("?");
    }

    public override void ActivateModule()
    {
        base.ActivateModule();
        this.printMenu();
    }

    public override void PlayerInputCallback(string input)
    {
        input = input.ToLower();
        char c = input[0];

        switch(c)
        {
            case 'n':
                this.loadCharacterCreation();
                break;
            case 's':
                this.loadSkinMenu();
                break;
            case 'q':
                QuitGame();
                break;
            default:
                printMenu();
                break;
        }
    }
}
