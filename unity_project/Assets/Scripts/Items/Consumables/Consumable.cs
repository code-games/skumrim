using UnityEngine;

public enum ConsumableType { Base, Recovery, Buff }

[CreateAssetMenu(menuName = "Skumrim/Items/Bases/Consumable")]
public class Consumable : Item
{
    public override ItemType getType()
    {
        return ItemType.Consumable;
    }

    public virtual ConsumableType getConsumableType()
    {
        return ConsumableType.Base;
    }
}
