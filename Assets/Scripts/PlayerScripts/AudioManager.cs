using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;


    private void Awake()
    {

        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (Sounds item in sounds)
        {
            item.audioSource = gameObject.AddComponent<AudioSource>();
            item.audioSource.clip = item.audioclip;
            item.audioSource.volume = item.volume;
            item.audioSource.pitch = item.pitch;
            item.audioSource.loop = item.audioLoop;
        }
    }
    public void Start()
    {

        PlayAudio("Background");
    }


    public void StopPlayAudio(string name)
    {
        Sounds s = Array.Find(sounds, Sounds => Sounds.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Hey Audioname" + name + "Not Found");
            return;
        }
        s.audioSource.Stop();
    }

    public void PlayAudio(string name)
    {
        Sounds s = Array.Find(sounds, Sounds => Sounds.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Hey Audioname " + name + " Not Found");
            return;
        }
        s.audioSource.Play();
    }

    public void SetVolume(string name, float volumeValue)
    {
        Sounds s = Array.Find(sounds, Sounds => Sounds.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Hey Audioname " + name + " Not Found");
            return;
        }
        else
        {
            s.audioSource.volume = volumeValue;
        }

    }
}