using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    MainMenu _mainmenu;
    WaveSpawner WaveSpawner;
    WaveSpawner2 WaveSpawner2;
    WaveSpawner3 WaveSpawner3;
    WaveSpawner4 WaveSpawner4;
    public bool GameOver = false;
    AudioManager audioManager;

    void Start() {
        {
      
        _mainmenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
        WaveSpawner = GetComponent<WaveSpawner>();
        WaveSpawner2 = GetComponent<WaveSpawner2>();
        WaveSpawner3 = GetComponent<WaveSpawner3>();
        WaveSpawner4 = GetComponent<WaveSpawner4>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
    }
    void Update()
    {

        if(WaveSpawner.WinActive && WaveSpawner2.WinActive && WaveSpawner3.WinActive && WaveSpawner4.WinActive && !GameOver)
        {
            Win();
            if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "Win1", "Win2"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
            
        }
    }

    void Win()
    {      
        GameOver = true;
          _mainmenu.LevelCounter();
          Debug.Log("Win");
          SceneManager.LoadSceneAsync(2);
    }
    
}
