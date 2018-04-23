using UnityEngine;
using UnityEngine.Events;

public class GameTimeUpdateEvent : UnityEvent { }
public class GameTimeFixedUpdateEvent : UnityEvent<float> { }

public class TimeManager : MonoBehaviour
{
    private GameTimeUpdateEvent gameTimeUpdate;
    private GameTimeFixedUpdateEvent gameTimeFixedUpdate;

    public bool isAdvancing;
    public float toAdvance;

    private void Awake()
    {
        gameTimeUpdate = new GameTimeUpdateEvent();
        gameTimeFixedUpdate = new GameTimeFixedUpdateEvent();

        isAdvancing = false;
        toAdvance = 0;
    }

    private void Update()
    {
        if (isAdvancing)
        {
            if (toAdvance != -1)
            {
                toAdvance -= Time.deltaTime;

                if (toAdvance <= 0)
                {
                    isAdvancing = false;
                    toAdvance = 0;
                }
            }

            gameTimeUpdate.Invoke();
        }
    }

    public void AdvanceFor(float seconds)
    {
        if (isAdvancing)
            toAdvance += seconds;
        else
        {
            toAdvance = seconds;
            isAdvancing = true;
        }

        gameTimeFixedUpdate.Invoke(seconds);
    }

    public void Advance()
    {
        toAdvance = -1;
        isAdvancing = true;
    }

    public void Stop()
    {
        isAdvancing = false;
    }

    public void SubscribeToGameTimeUpdate(UnityAction callback)
    {
        gameTimeUpdate.AddListener(callback);
    }

    public void UnsubscribeToGameTimeUpdate(UnityAction callback)
    {
        gameTimeUpdate.RemoveListener(callback);
    }

    public void SubscribeToGameTimeFixedUpdate(UnityAction<float> callback)
    {
        gameTimeFixedUpdate.AddListener(callback);
    }

    public void UnsubscribeToGameTimeFixedUpdate(UnityAction<float> callback)
    {
        gameTimeFixedUpdate.RemoveListener(callback);
    }
}
