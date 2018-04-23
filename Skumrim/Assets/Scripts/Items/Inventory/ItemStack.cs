
public class ItemStack
{
    public Inventory owner;

    public Item item { get; private set; }
    public int ammount { get; private set; }

    public ItemStack(Inventory owner, Item item, int ammount)
    {
        this.owner = owner;
        this.item = item;
        this.ammount = ammount;
    }

    public ItemStack(Inventory owner, Item item) : this(owner, item, 1) { }

    public void Add(int ammount)
    {
        this.ammount += ammount;
    }

    public void AddOne()
    {
        this.Add(1);
    }

    public bool Take(int ammount)
    {
        if (this.ammount < ammount)
        {
            return false;
        }

        this.ammount -= ammount;

        if (this.ammount == 0)
            owner.ClearStack(this);

        return true;
    }

    public bool TakeOne()
    {
        return Take(1);
    }

    public bool TakeAll()
    {
        return Take(ammount);
    }

    public void Show()
    {
        IOController.io.Log(this.ToString());
    }

    public override string ToString()
    {
        return ammount.ToString() + "\t" + item.ToString();
    }
}
