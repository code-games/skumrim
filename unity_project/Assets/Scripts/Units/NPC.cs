using UnityEngine;

[RequireComponent(typeof(Unit))]
public class NPC : MonoBehaviour
{
    public new string name;

    [HideInInspector]
    public Place location;
    [HideInInspector]
    public Unit unit;

    public bool isShopkeeper;

    public void Init(Place location)
    {
        this.location = location;
        unit = GetComponent<Unit>();
        unit.Init();
    }
}
