using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioManager Audio;
    void Start()
    {
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Audio.StopPlaying("ThemeMenu");
        Audio.StopPlaying("Defeat1");
        Audio.StopPlaying("Victory");
        Audio.StopPlaying("Theme");
        Audio.StopPlaying("Theme2");
        Audio.StopPlaying("Theme3");
        Audio.StopPlaying("Theme4");
        Audio.StopPlaying("Theme5");
        string[] possibleSounds = { "Theme", "Theme2", "Theme3", "Theme4", "Theme5"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        Audio.Play(selectedSound);
    }


}
