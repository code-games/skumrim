using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Interactables/CraftingStation")]
public class CraftingStation : InteractableObject
{
    public List<Recipe> recipes;

    public override void Interact()
    {
        CraftingManager.craftingManager.StartCrafting(recipes);
    }
}
