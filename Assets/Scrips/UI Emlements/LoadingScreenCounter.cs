using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingScreenCounter : MonoBehaviour
{

    public int nextLevel = 3;
	
    public TMP_Text LevelText;
    
    public int currentLevel;

private void Start()
    {
      
              if (PlayerPrefs.HasKey("SavedNextLevel"))
        {
            nextLevel = PlayerPrefs.GetInt("SavedNextLevel");
            currentLevel = nextLevel - 2;
        }
        else
        {
          nextLevel = 3;
          currentLevel = nextLevel - 2;
        }
        
              if(LevelText != null)
      {
        return;
      }
      else
      {
        if(!GameObject.Find("Level Counter"))
          return;
        LevelText = GameObject.Find("Level Counter").GetComponent<TextMeshProUGUI>();
        IncreaseLevel();
      }
    
    }

    


  public void IncreaseLevel()
    {
        nextLevel = PlayerPrefs.GetInt("SavedNextLevel");
        currentLevel = nextLevel - 2;
        LevelText.text = "Level: " + currentLevel + "/10";
    }
}
