using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public static ItemLibraryBasic Basics;
    public static ItemLibraryConsumables Consumables;
    public static ItemLibraryEquipment Equipments;

    private void Awake()
    {
        Basics = GetComponentInChildren<ItemLibraryBasic>();
        Consumables = GetComponentInChildren<ItemLibraryConsumables>();
        Equipments = GetComponentInChildren<ItemLibraryEquipment>();
    }
}
