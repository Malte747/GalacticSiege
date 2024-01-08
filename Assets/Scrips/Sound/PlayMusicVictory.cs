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
        Audio.Play("Victory");
    }

}
