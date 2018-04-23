using UnityEngine;

public enum GameMode { Normal, Hardcore, Dovahkiin }
public enum Difficulty { Medium, Hard }

public class GameSettings : MonoBehaviour
{
    public static GameSettings settings;

    public GameMode gameMode;
    public Difficulty difficulty;

    [Range(0, 100)]
    public int volume = 100;

    private void Awake()
    {
        settings = this;
    }
}
