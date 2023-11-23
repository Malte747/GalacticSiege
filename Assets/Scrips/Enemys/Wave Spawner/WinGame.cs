using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public int next = 1;
    void Update()
    {
        WaveSpawner WaveSpawner = GetComponent<WaveSpawner>();
        WaveSpawner2 WaveSpawner2 = GetComponent<WaveSpawner2>();
        WaveSpawner3 WaveSpawner3 = GetComponent<WaveSpawner3>();
        MainMenu levelCounter = GetComponent<MainMenu>();
      

        if(WaveSpawner.WinActive && WaveSpawner2.WinActive && WaveSpawner3.WinActive)
        {
            Win();
            levelCounter.LevelCounter();
        }
    }

    void Win()
    {
          Debug.Log("Win");
          SceneManager.LoadSceneAsync(2);
    }
    
}
