using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Quiver")]
public class EQUIP_Quiver : Equipment
{
    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Torso;
    }
}
