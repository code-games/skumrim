using UnityEngine;

public enum WeaponType { OneHanded, TwoHanded, Ranged }

[CreateAssetMenu( menuName = "Skumrim/Items/Weapon")]
public class Weapon : Equipment
{
    [Header("Weapon Properties")]
    public WeaponType weaponType;

    public int baseDamage;
}
