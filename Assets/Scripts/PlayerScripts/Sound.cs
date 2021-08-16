using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string audioName;
    public AudioClip audioclip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;
    public bool audioLoop;
    [HideInInspector]
    public AudioSource audioSource;

}