using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Interactables/StorageItem")]
public class StorageObject : InteractableObject
{
    public Inventory storage;

    public override void Init()
    {
        storage.Init();
    }

    public override void Interact()
    {
        StorageManager.storageManager.StartStoring(storage);
    }
}
