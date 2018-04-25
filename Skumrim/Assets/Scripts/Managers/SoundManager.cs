using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public List<Sound> sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
        }
    }

    public void StartGame()
    {
        getSoundByName("Rain").Play();
    }

    public Sound getSoundByName(string name)
    {
        return sounds.Find(s => s.name == name);
    }

    public Sound tryGettingSoundByName(string name)
    {
        Sound s = getSoundByName(name);

        if (s == null)
        {
            Debug.LogError("Sound '" + name + "' not found");
            return null;
        }

        return s;
    }

    public void PlaySoundByName(string name)
    {
        Sound s = tryGettingSoundByName(name);

        if(s != null)
            s.Play();
    }

    public void StopSoundByName(string name)
    {
        Sound s = tryGettingSoundByName(name);

        if (s != null)
            s.Stop();
    }

    public void PauseSoundByName(string name)
    {
        Sound s = tryGettingSoundByName(name);

        if (s != null)
            s.Pause();
    }

    public void UnPauseSoundByName(string name)
    {
        Sound s = tryGettingSoundByName(name);

        if (s != null)
            s.UnPause();
    }
}
