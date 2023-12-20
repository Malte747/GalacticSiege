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
        Audio.StopPlaying("Defeat");
        Audio.StopPlaying("Victory");
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
