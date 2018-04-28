using UnityEngine;

public class LockableObject : InteractableObject
{
    public bool startLocked;
    public bool locked { get; private set; }

    public override void Init()
    {
        base.Init();

        locked = startLocked;
    }

    public override bool Interact()
    {
        if (locked)
        {
            IOController.io.Log("The " + name + " is locked");
            return false;
        }

        return true;
    }

    public virtual void Lock() { locked = true; }

    public virtual void Unlock() { locked = false; }
}
