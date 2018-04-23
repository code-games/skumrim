using System.Collections.Generic;
using UnityEngine;

public class ItemLibraryArmor : ItemLibrary
{
    [HideInInspector]
    public List<ItemLibraryArmorSet> armorSets;

    public ItemLibraryArmorSet this[ArmorSet set]
    {
        get
        {
            foreach (ItemLibraryArmorSet s in armorSets)
            {
                if (s.armorSet == set)
                    return s;
            }
            return null;
        }
    }

    private void Awake()
    {         

        armorSets = new List<ItemLibraryArmorSet>();
        ItemLibraryArmorSet[] sets = GetComponentsInChildren<ItemLibraryArmorSet>();

        foreach (ItemLibraryArmorSet set in sets)
        {
            armorSets.Add(set);
        }
    }
}
