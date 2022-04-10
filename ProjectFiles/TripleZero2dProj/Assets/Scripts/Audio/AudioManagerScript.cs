using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class AudioManagerScript : MonoBehaviour
{
    // creates array for inidivual sounds
    public Sounds[] sounds;

    void Awake()
    {
        // loop that checks all current sounds, and gives them the volume and pitch variables
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }
    // function that will be called in other scripts to call upon sounds to be played
    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopPlaying(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            s.source.Stop();
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f));
        s.source.loop = false;

        s.source.Stop();
    }
}
