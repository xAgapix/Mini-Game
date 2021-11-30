using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour
{
    public SoundArray[] soundArray;
    public static AudioManager instance; 
    public List<string> SFXnameList = new List<string>();
    public List<string> GAMEnameList = new List<string>();
    
    private static readonly string firstPlay = "fp";
    private static readonly string gamePP = "gv";
    private static readonly string sfxPP = "se";
    float bgVolume;
    float sfxVolume; 
    public string BGMusic;

    void Awake(){
        foreach(SoundArray s in soundArray){
            
            s.sound = gameObject.AddComponent<AudioSource>();
            s.sound.clip = s.soundClip;
            s.sound.volume = s.volume;
            s.sound.loop = s.loop;
            s.sound.playOnAwake = s.playAwake;
        }
    }
    void Start(){
            
            PlaySound(BGMusic);
    }
    public void PlaySound(string name){
        SoundArray s = Array.Find(soundArray, findSound => findSound.soundName == name);
        Debug.Log("Played: "+name);
        
        
        if(s == null){
            Debug.LogWarning("Unable to find the Audio" + name);
        }
        s.sound.Play();
    }
  
    void Update()
    {
        bgVolume = PlayerPrefs.GetFloat(gamePP,0.5f);
        sfxVolume = PlayerPrefs.GetFloat(sfxPP,0.7f);

        VolumeUpdate();
        
        

    }
    
    void VolumeUpdate(){
        
        for(int i=0; i < SFXnameList.Count; i++){
            
            SoundArray s = Array.Find(soundArray, findSound => findSound.soundName == SFXnameList[i]);
        if(s == null){
            Debug.LogWarning("Unable to find the Audio VolUpd" + name);
        }
        s.sound.volume = sfxVolume;
        }


        for(int i=0; i < GAMEnameList.Count; i++){
            
            SoundArray s = Array.Find(soundArray, findSound => findSound.soundName == GAMEnameList[i]);
        if(s == null){
            Debug.LogWarning("Unable to find the Audio VolUpd" + name);
        }
        s.sound.volume = bgVolume;
        }

        
    }

}
