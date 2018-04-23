using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclusiveGameModule : MonoBehaviour, IGameModule
{
    #region IGameModule

    public virtual void ActivateModule()
    {
        IOController.io.grabExclusiveInput(PlayerActionInputCallback);
    }

    public virtual void DeactivateModule()
    {
        IOController.io.releaseExclusiveInput(PlayerActionInputCallback);
    }

    public virtual void PlayerActionInputCallback(string[] input) { }

    #endregion
}
