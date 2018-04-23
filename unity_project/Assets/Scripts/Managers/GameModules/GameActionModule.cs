using UnityEngine;

public class GameActionModule : MonoBehaviour, IGameModule
{
    public bool isActive { get; protected set; }

    public virtual void ActivateModule()
    {
        isActive = true;
        IOController.io.playerActionInputEvent.AddListener(PlayerActionInputCallback);
    }

    public virtual void DeactivateModule()
    {
        isActive = false;
        IOController.io.playerActionInputEvent.RemoveListener(PlayerActionInputCallback);
    }

    public virtual void PlayerActionInputCallback(string[] input) { }
}
