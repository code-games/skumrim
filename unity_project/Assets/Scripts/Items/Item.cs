using UnityEngine;

public enum ItemType { Basic, Equipment, Consumable }

[CreateAssetMenu( menuName = "Skumrim/Items/Bases/Item" )]
public class Item : ScriptableObject
{
    [Header("Item Properties")]
    public new string name;
    public int baseValue;
    public int weight;

    public override bool Equals(object other)
    {
        if (other is Item)
        {
            Item i = other as Item;

            return this == i;
        }

        return false;
    }

    public override int GetHashCode()
    {
        if (name == null) return -1;
        return name.GetHashCode();
    }

    public static bool operator ==(Item item1, Item item2)
    {
        if (object.ReferenceEquals(item1, null))
        {
            return object.ReferenceEquals(item2, null);
        }
        else if (object.ReferenceEquals(item2, null))
        {
            return false;
        }

        return item1.name == item2.name;
    }

    public static bool operator !=(Item item1, Item item2)
    {
        return !(item1 == item2);
    }


    public virtual ItemType getType()
    {
        return ItemType.Basic;
    }

    public virtual void Show()
    {
        IOController.io.Log(this.ToString());
    }

    public override string ToString()
    {
        string ret = string.Empty;

        ret = name + " - " + weight + "kg - " + baseValue + " gold";

        return ret;
    }

    public virtual bool Use()
    {
        IOController.io.Log(name + " is not a usable item");
        return false;
    }
}
