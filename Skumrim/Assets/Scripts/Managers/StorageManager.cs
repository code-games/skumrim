
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
        ShowStorage();
    }

    public void StopStoring()
    {
        this.storage = null;
        this.DeactivateModule();
    }

    public void ShowStorage()
    {
        storage.Display();
        IOController.io.LogLine();
    }

    private bool Store(string[] input)
    {
        string name;
        int ammount;
        Inventory playerInv = Player.player.inventory;

        if (!InputParseHelper.ParseTextAndNumberArgs(input, out name, out ammount))
            return false;

        if (name == "gold")
        {
            if (ammount > playerInv.gold)
                ammount = playerInv.gold;

            playerInv.RemoveGold(ammount);
            storage.AddGold(ammount);

            return true;
        }

        ItemStack stack = Player.player.inventory.getItemWithName(name);

        if (stack == null)
            return false;

        if (ammount > stack.ammount)
            ammount = stack.ammount;

        storage.AddItem(stack.item, ammount);
        stack.Take(ammount);

        return true;
    }

    private bool Retrieve(string[] input)
    {
        string name;
        int ammount;
        Inventory playerInv = Player.player.inventory;

        if (!InputParseHelper.ParseTextAndNumberArgs(input, out name, out ammount))
            return false;

        if (name == "gold")
        {
            if (ammount > storage.gold)
                ammount = storage.gold;

            storage.RemoveGold(ammount);
            playerInv.AddGold(ammount);

            return true;
        }

        ItemStack stack = storage.getItemWithName(name);

        if (stack == null)
            return false;

        if (ammount > stack.ammount)
            ammount = stack.ammount;

        Player.player.inventory.AddItem(stack.item, ammount);
        stack.Take(ammount);

        return true;
    }

    public override void PlayerActionInputCallback(string[] input)
    { 
        switch (input[0])
        {
            case "quit":
                StopStoring();
                return;
            case "take":
            case "retrieve":
            case "grab":
            case "get":
                Retrieve(input);
                break;
            case "store":
                Store(input);
                break;
            case "i":
            case "inventory":
            case "equip":
            case "equips":
            case "equipment":
            case "equipments":
                GameManager.Actions.PerformActionWithArguments(input);
                break;
        }

        ShowStorage();
    }
}
