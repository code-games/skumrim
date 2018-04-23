using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Items/Equipments/Arrow")]
public class EQUIP_Arrow : Equipment
{
    [Header("Arrow Properties")]
    public int baseDamage;

    public override EquipmentType getEquipmentType()
    {
        return EquipmentType.Arrow;
    }
}
