using UnityEngine;

public class GameModule : MonoBehaviour, IGameModule
{
    public bool isActive { get; protected set; }

    public virtual void ActivateModule()
    {
        isActive = true;
        IOController.io.playerInputEvent.AddListener(PlayerInputCallback);
    }

    public virtual void DeactivateModule()
    {
        isActive = false;
        IOController.io.playerInputEvent.RemoveListener(PlayerInputCallback);
    }

    public virtual void PlayerInputCallback(string input) { }
}
