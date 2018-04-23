using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Interactables/StorageItem")]
public class StorageObject : InteractableObject
{
    bool inventoryLoaded = false;
    public GameObject inventoryPrefab;
    Inventory storage;

    private void loadInventory()
    {
        storage = Instantiate(inventoryPrefab).GetComponent<Inventory>();
        inventoryLoaded = true;
    }

    public override void Interact()
    {
        if (!inventoryLoaded) loadInventory();

        StorageManager.storageManager.StartStoring(storage);
    }
}
