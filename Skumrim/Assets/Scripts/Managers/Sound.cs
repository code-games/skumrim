using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip audioClip;
    [HideInInspector]
    public AudioSource audioSource;

    [Range(0f, 1f)]
    public float volume;
    public bool loop;

    public void Play()
    {
        audioSource.Play();
    }

    public void Stop() { audioSource.Stop(); }

    public void Pause() { audioSource.Pause(); }

    public void UnPause() { audioSource.UnPause(); }
}
