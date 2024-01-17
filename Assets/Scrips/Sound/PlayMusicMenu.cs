using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicMenu : MonoBehaviour
{
 
 AudioManager Audio;
    void Start()
    {
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Audio.StopPlaying("Theme");
        Audio.StopPlaying("Theme2");
        Audio.StopPlaying("Theme3");
        Audio.StopPlaying("Theme4");
        Audio.StopPlaying("Theme5");
        Audio.StopPlaying("Defeat1");
        Audio.StopPlaying("Victory");
        Audio.StopPlaying("BossFight");
        Audio.Play("ThemeMenu");
    }

 public void ButtonPress()
 {
	FindObjectOfType<AudioManager>().Play("ButtonPress");
 }

 public void ButtonHover()
 {
	FindObjectOfType<AudioManager>().Play("ButtonHover");
 }
   
}
