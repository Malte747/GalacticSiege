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
     CameraFollow CameraFollow;
     UfoFly UfoFly;
     public bool GameOver = false;
     

    void Start() {
        {
      
        _mainmenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
        WaveSpawner = GetComponent<WaveSpawner>();
        WaveSpawner2 = GetComponent<WaveSpawner2>();
        WaveSpawner3 = GetComponent<WaveSpawner3>();
        WaveSpawner4 = GetComponent<WaveSpawner4>();
        CameraFollow = GameObject.Find("MainCamera").GetComponent<CameraFollow>();
        UfoFly = GameObject.Find("Ufo000").GetComponent<UfoFly>();
        }
    }
    void Update()
    {
        if(WaveSpawner.WinActive && WaveSpawner2.WinActive && WaveSpawner3.WinActive && WaveSpawner4.WinActive && !GameOver)
        {
            GameOver = true;
            Invoke("Win", 5f);
            CameraFollow.gamerunning = false;
            UfoFly.End();
            
        }
    }

    void Win()
    {      
       
          _mainmenu.LevelCounter();
          Debug.Log("Win");
          SceneManager.LoadSceneAsync(2);
    }
    
}
