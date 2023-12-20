using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
        MainMenu _mainmenu;
        private AudioManager audioManager;


        void Start()
        {
            _mainmenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
             audioManager = FindObjectOfType<AudioManager>();
        }


  public void NextSequence()
  {
    SceneManager.LoadSceneAsync(_mainmenu.nextLevel);

     if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "RStart1", "RStart2", "RStart3", "RStart4"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
    }
  
    

  public void Menu()
  {
    SceneManager.LoadSceneAsync(0);
 
  }

  public void TryAgain()
  {
     SceneManager.LoadSceneAsync(_mainmenu.nextLevel);
       

        if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "RStart1", "RStart2", "RStart3", "RStart4"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
    }

     
  

  public void PlayGame()
  { 
    SceneManager.LoadSceneAsync(_mainmenu.nextLevel);

     if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "RStart1", "RStart2", "RStart3", "RStart4"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
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
