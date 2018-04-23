using UnityEngine;

[CreateAssetMenu(menuName = "Skumrim/Interactables/Sign")]
public class Sign : InteractableObject
{
    [TextArea]
    public string sayings;

    public override void Look()
    {
        base.Look();
        IOController.io.Log("\"" + sayings + "\"");
    }

    public override void Interact()
    {
        base.Interact();
        IOController.io.Log("The sign reads: '" + sayings + "'");
    }
}
