using UnityEngine;
using UnityEngine.Events;

public class GameTimeTimer
{
    public float time;
    public bool loop;
    private float timer;
    private UnityAction callback;

    public GameTimeTimer(float time, UnityAction callback, bool loop)
    {
        this.time = time;
        this.callback = callback;
        this.loop = loop;
    }

    public GameTimeTimer(float time, UnityAction callback) : this(time, callback, false) { }

    public void Start()
    {
        this.timer = this.time;
        GameManager.GameTime.SubscribeToGameTimeUpdate(GameTimeUpdate);
    }

    public void StartForcing()
    {
        this.Start();
        GameManager.GameTime.AdvanceFor(time);
    }

    public void Stop()
    {
        GameManager.GameTime.UnsubscribeToGameTimeUpdate(GameTimeUpdate);
    }

    public void GameTimeUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if(!loop) this.Stop();
            callback.Invoke();
        }
    }
}
