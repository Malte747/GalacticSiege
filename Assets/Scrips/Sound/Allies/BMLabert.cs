using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMLabert : MonoBehaviour
{
   private AudioManager audioManager;   
    public GameObject speachbubble;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        Invoke("Talk", 3f);
    }



    void Talk()
    {
        string[] possibleSounds = { "BM1", "BM2", "BM3", "BM4", "BM5", "BM6", "BM7", "BM8", "BM9", "BM10", "BM11", "BM12", "BM13", "BM14", "BM15"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        audioManager.Play(selectedSound);

        if (speachbubble != null)
        {
            speachbubble.SetActive(true);
            Invoke("SpeachEnd", 3f);
        }
        
    }

    void SpeachEnd()
    {
        speachbubble.SetActive(false);
    }
}
