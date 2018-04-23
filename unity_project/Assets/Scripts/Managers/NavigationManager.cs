using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public List<Place> allLocations;
    public Place currentLocation;

    [HideInInspector]
    public Place goingTo;
    public GameTimeTimer goingToTimer;

    public Place getLocation(Place p)
    {
        if (p == null) return null;

        p = allLocations.Find(place => place.id == p.id);

        return p;
    }

    public void StartGame()
    {
        foreach (Place p in allLocations)
        {
            p.Init();
        }

        currentLocation.OnPlayerEnter();
    }

    public void MoveTo(Place p)
    {
        currentLocation.OnPlayerExit();
        currentLocation = p;
        currentLocation.OnPlayerEnter();
    }

    public void MoveToPlaceWithDelay(Place p, float delay)
    {
        IOController.io.readyToAct = false;
        currentLocation.OnPlayerExit();
        goingTo = p;
        goingToTimer = new GameTimeTimer(delay, MoveToCallback);
        goingToTimer.StartForcing();
    }

    private void MoveToCallback()
    {
        currentLocation = goingTo;
        goingTo = null;
        goingToTimer = null;

        currentLocation.OnPlayerEnter();

        IOController.io.readyToAct = true;
    }
}
