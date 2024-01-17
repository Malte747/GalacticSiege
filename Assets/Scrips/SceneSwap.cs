using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class SceneSwap : MonoBehaviour
{
        MainMenu _mainmenu;
        private AudioManager audioManager;
        public bool inMenu = true;

        public GameObject loadingScreen;
        public Slider slider;

        public GameObject StartButtonDeactivate;
        public GameObject LevelCountDeactivate;
        private bool GameDone = false;

  void Start()
    {
        _mainmenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
         audioManager = FindObjectOfType<AudioManager>();

        if (StartButtonDeactivate != null && LevelCountDeactivate != null && _mainmenu.nextLevel >= 13)
        {
            StartButtonDeactivate.SetActive(false);
            LevelCountDeactivate.SetActive(false);
        }
    }

    void FixedUpdate()
    {
      if (StartButtonDeactivate != null && LevelCountDeactivate != null && _mainmenu.nextLevel == 13 && !GameDone)
        {
            GameDone = true;
            StartButtonDeactivate.SetActive(false);
            LevelCountDeactivate.SetActive(false);
        }
    }


  public void NextSequence()
  {
    if(inMenu == true)
    {
    inMenu = false;
    int sceneIndex = _mainmenu.nextLevel;
    loadingScreen.SetActive(true);
    StartCoroutine(LoadAsynchronously(sceneIndex));

     if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "RStart1", "RStart2", "RStart3", "RStart4", "RStart5", "RStart6", "RStart7", "RStart8", "RStart9"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
    }
  }
    

  public void Menu()
  {
    SceneManager.LoadSceneAsync(0);
 
  }

  public void TryAgain()
  {
    if(inMenu == true)
    {
    inMenu = false;
    int sceneIndex = _mainmenu.nextLevel;
    loadingScreen.SetActive(true);
    StartCoroutine(LoadAsynchronously(sceneIndex));
       

        if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "RStart1", "RStart2", "RStart3", "RStart4", "RStart5", "RStart6", "RStart7", "RStart8", "RStart9"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
    }
  }

     
  

  public void PlayGame()
  { 
    if(inMenu == true)
    {
    inMenu = false;
    int sceneIndex = _mainmenu.nextLevel;
    loadingScreen.SetActive(true);
    StartCoroutine(LoadAsynchronously(sceneIndex));

     if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "RStart1", "RStart2", "RStart3", "RStart4", "RStart5", "RStart6", "RStart8", "RStart9"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
    }
  }


  IEnumerator LoadAsynchronously (int sceneIndex)
  {
      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
      AsyncOperation operation1 = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
      AsyncOperation operation2 = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);


      while (!operation.isDone && !operation1.isDone && !operation2.isDone)
      {
        float progress = Mathf.Clamp01(operation.progress / .9f);
        slider.value = progress;

        yield return null;
      }

  }





  public void Reset()
  {
    _mainmenu.ResetLevel();
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
