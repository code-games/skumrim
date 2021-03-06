using UnityEngine;

public class InteractableObject : ScriptableObject
{
    public new string name;
    public string description;

    public virtual void Init() { }

    public virtual void Describe()
    {
        IOController.io.Log("[" + name + " - " + description + "]");
    }

    public virtual bool Interact()
    {
        IOController.io.Log("Interacting with: " + name);
        return true;
    }

    public virtual void Look()
    {
        IOController.io.Log(description);
    }
}
