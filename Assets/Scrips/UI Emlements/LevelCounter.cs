using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
  MainMenu MainMenu;
   public TMP_Text LevelText;
   

    void Start()
    {   
         MainMenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
        LevelText.text = "Level: " + MainMenu.currentLevel;
    }


    public void IncreaseLevel()
    {
        Debug.Log(MainMenu.currentLevel);
        MainMenu.currentLevel = MainMenu.nextLevel - 0;
        LevelText.text = "Level: " + MainMenu.currentLevel;
    }
}
