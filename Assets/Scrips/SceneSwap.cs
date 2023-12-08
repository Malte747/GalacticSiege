using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
        MainMenu _mainmenu;



        void Start()
        {
            _mainmenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
        }


  public void NextSequence()
  {
    SceneManager.LoadSceneAsync(_mainmenu.nextLevel);
    
  }

  public void Menu()
  {
    SceneManager.LoadSceneAsync(0);
    
  }

  public void TryAgain()
  {
     SceneManager.LoadSceneAsync(_mainmenu.nextLevel);
     
  }

  public void PlayGame()
  { 
    SceneManager.LoadSceneAsync(_mainmenu.nextLevel);
    
  }






}
