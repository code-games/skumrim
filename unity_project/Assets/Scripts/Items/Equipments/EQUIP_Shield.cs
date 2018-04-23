using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Shield")]
public class EQUIP_Shield : Equipment
{
    [Header("Shield Properties")]
    public int baseBlock;

    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Shield;
    }
}
