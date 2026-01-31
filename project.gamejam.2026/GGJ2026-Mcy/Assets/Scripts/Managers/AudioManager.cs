using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        SetupAudios();
    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound != null)
        {
            sound.source.PlayOneShot(sound.clip);
        }
    }
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound != null)
        {
            sound.source.Play();
        }
    }
    public void StopSFX(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound != null)
        {
            sound.source.Stop();
        }
    }

    void SetupAudios()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.isLoop;
            sound.source.playOnAwake = sound.isPlayAwake;
        }
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [HideInInspector] public AudioSource source;
    [Range(0f, 1f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;
    public bool isLoop = false;
    public bool isPlayAwake = false;
}
