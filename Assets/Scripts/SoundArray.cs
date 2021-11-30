using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class SoundArray
{
    public AudioClip soundClip;
   public string soundName;
   public float volume;
   public bool loop;
   public bool playAwake;
   [HideInInspector]
   public AudioSource sound;
}
