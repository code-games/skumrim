using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Ring")]
public class EQUIP_Ring : Equipment
{
    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Ring;
    }
}
