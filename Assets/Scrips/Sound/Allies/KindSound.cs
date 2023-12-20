using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KindSound : MonoBehaviour
{
    
private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "Kind1", "Kind2", "Kind3", "Kind4", "Kind5", "Kind6", "Kind7"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
    }


}
