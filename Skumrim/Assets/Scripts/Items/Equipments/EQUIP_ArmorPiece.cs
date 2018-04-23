using UnityEngine;

public enum ArmorType { Light, Heavy }
public enum ArmorSet
{
    NoSet,
    Hide,
    Leather,
    LightChitin,
    ElvenLight,
    Scaled,
    LightStalhrim,
    Glass,
    Dragonscale,

    Iron,
    Bonemold,
    Steel,
    HeavyChitin,
    Elven,
    Dwarven,
    SteelPlate,
    Nordic,
    Orcish,
    Ebony,
    HeavyStalhrim,
    Dragonplate,
    Daedric
}

public class EQUIP_ArmorPiece : Equipment
{
    [Header("Armor Piece Properties")]
    public ArmorType armorType;
    public ArmorSet set;
    public int baseDamageBlock;
}
