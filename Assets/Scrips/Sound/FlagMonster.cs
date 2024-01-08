using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMonster : MonoBehaviour
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
        string[] possibleSounds = { "Flag1", "Flag2", "Flag3", "Flag4", "Flag5", "Flag6", "Flag7", "Flag8", "Flag9",};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
    }
}
