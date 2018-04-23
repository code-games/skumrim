using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Necklace")]
public class EQUIP_Necklace : Equipment
{
    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Necklace;
    }
}
