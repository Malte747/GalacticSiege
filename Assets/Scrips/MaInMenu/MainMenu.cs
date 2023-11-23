using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public int nextLevel = 3;
	

  private static MainMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

  public void LevelCounter()
  {
    nextLevel++;
  }

  public void PlayGame()
  {
    SceneManager.LoadSceneAsync(nextLevel);
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  public void NextSequence()
  {
    SceneManager.LoadSceneAsync(nextLevel);
  }

  public void Menu()
  {
    SceneManager.LoadSceneAsync(0);
  }

  public void TryAgain()
  {
     SceneManager.LoadSceneAsync(nextLevel);
  }

  
}
