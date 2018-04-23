using UnityEngine;

public enum EquipmentType
{
    Base, //Not supposed to be equipped
    Head, //Helmet, Hat, Circlet
    Torso, //Armor, Clothing, Robes
    Legs, //Boots, Shoes
    Arms, //Gauntlets, Gloves
    Necklace, //Only one at a time
    Ring,   //Can wear 10 at a time
    Weapon, //Any type of weapon
    Shield, //Can be used for blocking... yep
    Quiver, //Holds Arrows... yep
    Arrow   //They get shot by bows... yep
}

[CreateAssetMenu( menuName = "Skumrim/Items/Bases/Equipment" )]
public class Equipment : Item
{
    public override ItemType getType()
    {
        return ItemType.Equipment;
    }

    public virtual EquipmentType getEquipmentType()
    {
        return EquipmentType.Base;
    }
}
