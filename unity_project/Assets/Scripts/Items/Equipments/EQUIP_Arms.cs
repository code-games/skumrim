using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Arms")]
public class EQUIP_Arms : EQUIP_ArmorPiece
{
    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Arms;
    }
}
