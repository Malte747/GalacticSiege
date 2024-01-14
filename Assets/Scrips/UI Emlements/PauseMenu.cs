using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false; // Zustand der Pause
    private bool allowInput = true;
    public Button uiButton;
    public Button uiButton2;
    public Button uiButton3;
    public Button[] uiButtonEnterArray;
    public Button[] uiButtonEnterArray2;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // P-Taste als Toggel für Pause/Weiterführung
        {
            SimulateButtonPress();        
        }

        if (Input.GetKeyDown(KeyCode.Return)) // P-Taste als Toggel für Pause/Weiterführung
        {

            SimulateButtonPressEnter();        
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) // P-Taste als Toggel für Pause/Weiterführung
        {

            SimulateButtonPressEnter2();        
        }
        if (Input.GetKeyDown(KeyCode.Q)) // P-Taste als Toggel für Pause/Weiterführung
        {

               SimulateButtonPressQ();   
        }
    }



       void SimulateButtonPress()
    {
        if (uiButton.isActiveAndEnabled)
        {
            uiButton.onClick.Invoke(); // Simuliert einen Klick auf den UI-Button
        }
        else if (uiButton2.isActiveAndEnabled)
        {
            uiButton2.onClick.Invoke();
        }
        else return;

    }

    void SimulateButtonPressQ()
    {
        if (uiButton3.isActiveAndEnabled)
        {
            uiButton3.onClick.Invoke(); // Simuliert einen Klick auf den UI-Button
        }

    }
      

    void SimulateButtonPressEnter()
    {
        // Aktiven Button aus dem Array finden
        foreach (Button button in uiButtonEnterArray)
        {
            if (button != null && button.isActiveAndEnabled)
            {
                button.onClick.Invoke(); // Simuliert einen Klick auf den aktiven UI-Button
                break; // Stoppt die Schleife, sobald der aktive Button gefunden wurde
            }
        }
    }

        void SimulateButtonPressEnter2()
    {
        // Aktiven Button aus dem Array finden
        foreach (Button button in uiButtonEnterArray2)
        {
            if (button != null && button.isActiveAndEnabled)
            {
                button.onClick.Invoke(); // Simuliert einen Klick auf den aktiven UI-Button
                break; // Stoppt die Schleife, sobald der aktive Button gefunden wurde
            }
        }
    }


    public void TogglePause()
    {
        isPaused = !isPaused; // Ändert den Pausenzustand

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausiert das Spiel, indem die Zeit auf 0 gesetzt wird
            // Hier könntest du weitere Aktionen hinzufügen, die beim Pausieren ausgeführt werden sollen
            Debug.Log("Spiel pausiert");
        }
        else
        {
            Time.timeScale = 1f; // Setzt die Zeit wieder auf Normal, um das Spiel fortzusetzen
            // Hier könntest du zusätzliche Aktionen hinzufügen, die beim Fortsetzen des Spiels ausgeführt werden sollen
            Debug.Log("Spiel fortgesetzt");
        }
    }

    // Du kannst diese Methode aufrufen, um das Spiel zu pausieren oder fortzusetzen, von anderen Skripten aus
    public void PauseGame()
    {
        TogglePause();
    }
}

