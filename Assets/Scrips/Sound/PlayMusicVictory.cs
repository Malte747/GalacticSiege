using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicVictory : MonoBehaviour
{
  AudioManager Audio;
    void Start()
    {
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Audio.StopPlaying("ThemeMenu");
        Audio.StopPlaying("Defeat1");
        Audio.StopPlaying("Theme");
        Audio.StopPlaying("Theme2");
        Audio.StopPlaying("Theme3");
        Audio.StopPlaying("Theme4");
        Audio.StopPlaying("Theme5");
        Audio.Play("Victory");
    }

}
