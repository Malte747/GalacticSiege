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

    void Update()
    {
      if(LevelText != null)
      {
        return;
      }
      else
      {
        LevelText = GameObject.Find("Level Count").GetComponent<TextMeshProUGUI>();
        IncreaseLevel();
      }
    }

  public void LevelCounter()
  {
    nextLevel++;
    
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
