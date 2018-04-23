using System.Collections.Generic;
using UnityEngine;

public class Action : ScriptableObject
{
    public List<string> aliases;

    public bool isStringIdentifier(string id)
    {
        return id == this.name || aliases.Contains(id);
    }

    public virtual void Perform(string[] arguments) { Debug.Log("Performing Action: " + name); }
}
