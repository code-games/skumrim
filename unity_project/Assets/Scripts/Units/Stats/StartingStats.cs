using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Starting Stats")]
public class StartingStats : ScriptableObject
{
    public int maxHitPoints;
    public int maxMagicka;
    public int maxStamina;

    [Header("Skills")]

    [Header("Combat")]
    [Range(1, 100)] public int archery;
    [Range(1, 100)] public int oneHanded;
    [Range(1, 100)] public int twoHanded;
    [Range(1, 100)] public int block;
    [Range(1, 100)] public int heavyArmor;
    [Range(1, 100)] public int lightArmor;

    [Header("Magic")]
    [Range(1, 100)] public int alteration;
    [Range(1, 100)] public int conjuration;
    [Range(1, 100)] public int destruction;
    [Range(1, 100)] public int illusion;
    [Range(1, 100)] public int restoration;

    [Header("Thief")]
    [Range(1, 100)] public int lockpicking;
    [Range(1, 100)] public int pickpocket;
    [Range(1, 100)] public int sneak;

    [Header("Crafting")]
    [Range(1, 100)] public int smithing;
    [Range(1, 100)] public int enchanting;
    [Range(1, 100)] public int alchemy;
    [Range(1, 100)] public int cooking;

    [Header("Other")]
    [Range(1, 100)] public int search;
    [Range(1, 100)] public int speech;
    [Range(1, 100)] public int hunting;
}
