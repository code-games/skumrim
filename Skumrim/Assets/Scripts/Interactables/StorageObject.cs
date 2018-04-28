using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Interactables/StorageItem")]
public class StorageObject : LockableObject
{
    public Inventory storage;

    public override void Init()
    {
        base.Init();
        storage.Init();
    }

    public override bool Interact()
    {
        if (base.Interact())
        {
            StorageManager.storageManager.StartStoring(storage);
            return true;
        }

        return false;
    }
}
