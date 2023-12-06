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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // P-Taste als Toggel für Pause/Weiterführung
        {
            SimulateButtonPress();        
        }
    }



       void SimulateButtonPress()
    {
        if (uiButton.isActiveAndEnabled)
        {
            uiButton.onClick.Invoke(); // Simuliert einen Klick auf den UI-Button
        }
        else
        {
            uiButton2.onClick.Invoke();
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

