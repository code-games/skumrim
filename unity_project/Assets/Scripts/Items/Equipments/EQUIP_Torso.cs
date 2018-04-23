using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Torso")]
public class EQUIP_Torso : EQUIP_ArmorPiece
{
    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Torso;
    }
}
