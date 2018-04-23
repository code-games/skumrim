using System.Collections.Generic;
using UnityEngine;

public class ItemLibraryBasic : MonoBehaviour
{
    public List<Item> items;

    public virtual Item makeItem(string name)
    {
        foreach (Item i in items)
        {
            if (i.name == name)
            {
                return Instantiate(i);
            }
        }

        return null;
    }
}
