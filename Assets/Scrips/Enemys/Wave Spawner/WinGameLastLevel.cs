using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameLastLevel : MonoBehaviour
{
     MainMenu _mainmenu;
     WaveSpawner WaveSpawner;
     WaveSpawner2 WaveSpawner2;
     WaveSpawner3 WaveSpawner3;
     WaveSpawner4 WaveSpawner4;
     CameraFollow CameraFollow;
     UfoFly UfoFly;
     public bool GameOver = false;
     AudioManager Audio;

     public GameObject UIHeathBarDeactivate;
     public GameObject UIUltBarDeactivate;
     public GameObject UIRageBarDeactivate;
     public GameObject UISummonDeactivate;

    public GameObject Ufo; // Das GameObject, das du spawnen möchtest
    public Vector3 spawnPosition;
     

    void Start() {
        {
        _mainmenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
        WaveSpawner = GetComponent<WaveSpawner>();
        WaveSpawner2 = GetComponent<WaveSpawner2>();
        WaveSpawner3 = GetComponent<WaveSpawner3>();
        WaveSpawner4 = GetComponent<WaveSpawner4>();
        CameraFollow = GameObject.Find("MainCamera").GetComponent<CameraFollow>();
        UfoFly = GameObject.Find("Ufo000").GetComponent<UfoFly>();
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
    }
    void Update()
    {
        if(WaveSpawner.WinActive && WaveSpawner2.WinActive && WaveSpawner3.WinActive && WaveSpawner4.WinActive && !GameOver)
        {
            GameOver = true;
            Invoke("Win", 5f);
            CameraFollow.gamerunning = false;
            UfoFly.FakeEnd();
            UIHeathBarDeactivate.SetActive(false);
            UIRageBarDeactivate.SetActive(false);
            UISummonDeactivate.SetActive(false);
            UIUltBarDeactivate.SetActive(false);
            Instantiate(Ufo, spawnPosition, Quaternion.identity);

            Audio.StopPlaying("Defeat1");
            Audio.StopPlaying("ThemeMenu");
            Audio.StopPlaying("Theme");
            Audio.StopPlaying("Theme2");
            Audio.StopPlaying("Theme3");
            Audio.StopPlaying("Theme4");
            Audio.StopPlaying("Theme5");
            Audio.Play("BossFight");
        }
    }

    void Win()
    {      
            CameraFollow.gamerunning = true;
            CameraFollow.FinalLevel();
            UIHeathBarDeactivate.SetActive(true);
            UIRageBarDeactivate.SetActive(true);
            UISummonDeactivate.SetActive(true);
            UIUltBarDeactivate.SetActive(true);
            

    }

        public void ActivateGameObjects()
    {
                // Holen Sie sich alle GameObjects in der aktuellen Szene
        GameObject[] allGameObjects = SceneManager.GetSceneByBuildIndex(2).GetRootGameObjects();

        // Deaktiviere jedes GameObject
        foreach (GameObject go in allGameObjects)
        {
            go.SetActive(true);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

        void DeactivateLevel()
    {

        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();


        foreach (GameObject go in allGameObjects)
        {
            go.SetActive(false);
        }
        
    }
    
}
