using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicDefeat : MonoBehaviour
{
  AudioManager Audio;
    void Start()
    {
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Audio.StopPlaying("Victory");
        Audio.StopPlaying("ThemeMenu");
        Audio.StopPlaying("Theme");
        Audio.Play("Defeat1");
    }
}
