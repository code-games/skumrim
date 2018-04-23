using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/UISkin")]
public class UISkin : ScriptableObject
{
    public string description;

    [Header("Base Colors")]
    public Color textColor;
    public Color backgroundColor;
    public Color sidePanelColor;

    [Header("Special text colors")]
    public Color errorTextColor;
    public Color lewdTextColor;
    public Color accentTextColor;
    public Color systemTextColor;
    public Color playerTextColor;

    public void Describe()
    {
        IOController.io.Log(this.name + " - " + this.description);
    }
}
