using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Legs")]
public class EQUIP_Legs : EQUIP_ArmorPiece
{
    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Legs;
    }
}
