using UnityEngine;

public class InteractableObject : ScriptableObject
{
    public new string name;
    public string description;

    public virtual void Describe()
    {
        IOController.io.Log("[" + name + " - " + description + "]");
    }

    public virtual void Interact()
    {
        IOController.io.Log("Interacting with: " + name);
    }

    public virtual void Look()
    {
        IOController.io.Log(description);
    }
}
