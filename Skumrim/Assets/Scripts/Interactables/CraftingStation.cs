using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Interactables/CraftingStation")]
public class CraftingStation : InteractableObject
{
    public List<Recipe> recipes;

    public override bool Interact()
    {
        bool ret = base.Interact();

        CraftingManager.craftingManager.StartCrafting(recipes);

        return ret;
    }
}
