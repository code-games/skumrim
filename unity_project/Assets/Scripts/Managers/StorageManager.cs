
public class StorageManager : ExclusiveGameModule
{
    #region Singleton

    public static StorageManager storageManager;
    private void Awake()
    {
        storageManager = this;
    }

    #endregion

    Inventory storage;

    public void StartStoring(Inventory storage)
    {
        this.storage = storage;
        this.ActivateModule();
        storage.Display();
    }

    public void StopStoring()
    {
        this.storage = null;
        this.DeactivateModule();
    }

    public void ShowStorage()
    {
        storage.Display();
    }

    public override void PlayerActionInputCallback(string[] input)
    {
        
    }
}
