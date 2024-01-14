using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BmSound : MonoBehaviour
{

     private bool hilfe = true;
    private AudioManager audioManager;   

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }




    public void BMSound()
        {
        
        string[] possibleSounds = { "BM1", "BM2", "BM3", "BM4", "BM5", "BM6", "BM7", "BM8", "BM9", "BM10", "BM11", "BM12", "BM13", "BM14", "BM15"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        audioManager.Play(selectedSound);
        }

    public void BMSchreit()
    {
       audioManager.Play("BMSchreit"); 
    }
    public void BMSchreitDelay()
    {
       Invoke("BMSchreit", 3f);
    }

        public void BMHilfe()
    {
        if(hilfe)
        {
            hilfe = false;
            audioManager.Play("BMHilfe"); 
        }
    }




}
