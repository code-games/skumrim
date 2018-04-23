using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Skumrim/Locations/Place")]
public class Place : ScriptableObject
{
    #region Properties

    public int id;
    public new string name;

    [TextArea]
    public string description;

    [Space(15)]

    public Action[] actions;

    public List<NPC> startingNPCS;
    [HideInInspector]
    public List<NPC> npcs;
    public bool hasNPCs { get { return npcs.Count > 0; } }

    public List<InteractableObject> interactables;
    public bool hasInteractables { get { return interactables.Count > 0; } }

    [Header("Exits")]
    public Place north;
    public Place east;
    public Place south;
    public Place west;

    public Place[] exits;

    public bool hasObviousExits
    {
        get { return north != null || east != null || south != null || west != null || exits.Length > 0; }
    }

    public bool hasWildlife;

    #endregion

    #region Methods

    #region Place Lifecycle

    public virtual void Init()
    {
        npcs = new List<NPC>();
        NPC instance;

        foreach (NPC npc in startingNPCS)
        {
            instance = Instantiate(npc);
            instance.Init(this);
            npcs.Add(instance);
        }
    }

    public virtual void OnPlayerEnter() { this.Describe(); }

    public virtual void OnPlayerExit() { }

    #endregion

    #region Exits

    public Place getExitByName(string name)
    {
        NavigationManager nm = GameManager.Navigation;

        if (name == "north" || name == "n")
            return nm.getLocation(this.north);
        if (name == "east" || name == "e")
            return nm.getLocation(this.east);
        if (name == "south" || name == "s")
            return nm.getLocation(this.south);
        if (name == "west" || name == "w")
            return nm.getLocation(this.west);

        foreach (Place exit in exits)
        {
            if (exit.name == name)
                return nm.getLocation(exit);
        }

        return null;
    }

    public List<Place> getAllExits()
    {
        List<Place> ret = new List<Place>(exits);

        if (north) ret.Add(north);
        if (east) ret.Add(east);
        if (south) ret.Add(south);
        if (west) ret.Add(west);

        return ret;
    }

    #endregion

    #region Description

    public virtual void Describe()
    {
        IOController.io.LogLine();

        IOController.io.LogAccent(this.name);
        IOController.io.Log("\t" + description);

        this.DescribeNPCs();
        this.DescribeInteractables();
        this.DescribeExits();

        IOController.io.LogLine();
    }

    public virtual void DescribeNPCs()
    {
        if (this.hasNPCs)
        {
            IOController io = IOController.io;

            io.InlineLog("[");
            io.InlineLogAccent("NPCs: ");

            foreach (NPC npc in npcs)
            {
                io.InlineLog(npc.name + ", ");
            }

            io.TrimInlineBuffer(2);
            io.InlineLog("]");

            io.FlushInlineLog();
        }
    }

    public virtual void DescribeInteractables()
    {
        if (this.hasInteractables)
        {
            IOController io = IOController.io;

            io.InlineLog("[");
            io.InlineLogAccent("Objects: ");

            foreach (InteractableObject item in interactables)
            {
                io.InlineLog(item.name + ", ");
            }

            io.TrimInlineBuffer(2);
            io.InlineLog("]");

            io.FlushInlineLog();
        }
    }

    public virtual void DescribeExits()
    {
        if (this.hasObviousExits)
        {
            IOController io = IOController.io;

            io.InlineLog("[");
            io.InlineLogAccent("Exits: ");

            if (north) io.InlineLog("north, ");
            if (east) io.InlineLog("east, ");
            if (south) io.InlineLog("south, ");
            if (west) io.InlineLog("west, ");

            if (exits.Length > 0)
                foreach (Place exit in exits)
                    io.InlineLog(exit.name + ", ");

            io.TrimInlineBuffer(2);

            io.InlineLog("]");

            io.FlushInlineLog();
        }
    }

    #endregion

    public bool PerformActionWithArguments(string[] arguments)
    {
        bool ret = false;

        foreach (Action action in actions)
        {
            if (action.isStringIdentifier(arguments[0]))
            {
                ret = true;
                action.Perform(arguments);
                break;
            }
        }

        return ret;
    }

    public NPC getNPCByName(string name)
    {
        name = name.ToLower();

        foreach (NPC npc in npcs)
        {
            if (npc.name.ToLower() == name)
                return npc;
        }

        return null;
    }

    public InteractableObject getInteractableByName(string name)
    {
        return interactables.Find(i => i.name.ToLower() == name.ToLower());
    }

    #endregion
}
