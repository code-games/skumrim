using UnityEngine;
using UnityEngine.UI;

public class SidePanelController : MonoBehaviour
{
    public Image background;

    public Text charName;
    public Image charImage;

    private void Start()
    {
        charName.text = Player.player.name;
    }
}
