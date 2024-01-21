using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	public int nextLevel = 3;
	
    public TMP_Text LevelText;
    
    public int currentLevel;


  private static MainMenu instance;

    private void Awake()
    {
              if (PlayerPrefs.HasKey("SavedNextLevel"))
        {
            nextLevel = PlayerPrefs.GetInt("SavedNextLevel");
            currentLevel = nextLevel - 2;
        }
        else
        {
            nextLevel = 3; // Standardwert
            currentLevel = 1; // Standardwert
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
         SaveLevel();
    }

    void Update()
    {
      if(LevelText != null)
      {
        return;
      }
      else
      {
        if(!GameObject.Find("Level Count"))
          return;
        LevelText = GameObject.Find("Level Count").GetComponent<TextMeshProUGUI>();
        IncreaseLevel();
      }
    }

  public void LevelCounter()
  {
    nextLevel++;
    SaveLevel(); // Speichert den nächsten Level
  }

public void ResetLevel()
{
  nextLevel = 3;
  SaveLevel(); // Speichert den nächsten Level
}

private void SaveLevel()
    {
        PlayerPrefs.SetInt("SavedNextLevel", nextLevel);
        PlayerPrefs.Save(); // Speichert die Einstellungen
    }

  public void IncreaseLevel()
    {
        
        currentLevel = nextLevel - 2;
        LevelText.text = "Level: " + currentLevel;
    }

  public void QuitGame()
  {
    Application.Quit();
  }





  
}
