using UnityEngine;

public enum RecoveryConsumableType { Hitpoints, Magicka, Stamina, All }

[CreateAssetMenu(menuName = "Skumrim/Items/Consumables/Recovery")]
public class RecoveryConsumable : Consumable
{
    public RecoveryConsumableType recoveryConsumableType;
    public int recoveryValue;

    public override ConsumableType getConsumableType()
    {
        return ConsumableType.Recovery;
    }
}
