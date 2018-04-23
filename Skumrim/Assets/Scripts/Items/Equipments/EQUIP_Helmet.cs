using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Helmet")]
public class EQUIP_Helmet : EQUIP_ArmorPiece
{
    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Head;
    }
}
