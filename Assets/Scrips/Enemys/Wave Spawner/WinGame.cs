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
    public bool GameOver = false;

    void Start() {
        {
      
        _mainmenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
        WaveSpawner = GetComponent<WaveSpawner>();
        WaveSpawner2 = GetComponent<WaveSpawner2>();
        WaveSpawner3 = GetComponent<WaveSpawner3>();
        }
    }
    void Update()
    {

        if(WaveSpawner.WinActive && WaveSpawner2.WinActive && WaveSpawner3.WinActive && !GameOver)
        {
            Win();
            
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
