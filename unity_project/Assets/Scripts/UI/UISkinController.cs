using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkinController : MonoBehaviour
{
    public static UISkinController skinController;

    public Image background;
    public Text text;
    public InputField inputField;
    public SidePanelController sidePanel;

    public UISkin skin;
    public UISkin[] availableSkins;

    private void Awake()
    {
        skinController = this;
    }

    void Start()
    {
        UpdateSkinSettings();
    }

    private void OnDrawGizmos()
    {
        UpdateSkinSettings();
    }

    public void UpdateSkinSettings()
    {
        background.color = skin.backgroundColor;
        text.color = skin.textColor;
        sidePanel.background.color = skin.sidePanelColor;

        List<Text> texts = new List<Text>();
        texts.AddRange(inputField.GetComponentsInChildren<Text>());
        texts.AddRange(sidePanel.GetComponentsInChildren<Text>());

        foreach (Text t in texts)
        {
            t.color = skin.playerTextColor;
        }
    }

    public void ListAvailableSkins()
    {
        IOController.io.Log("Available Skins:");

        foreach (UISkin s in availableSkins)
        {
            s.Describe();
        }

        IOController.io.LogLine();
    }

    public bool SetSkinByName(string name)
    {
        bool ret = false;

        foreach (UISkin s in availableSkins)
        {
            if (s.name == name)
            {
                ret = true;
                skin = s;
                UpdateSkinSettings();
                break;
            }
        }

        return ret;
    }
}
