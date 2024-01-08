using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZone2 : MonoBehaviour
{

    public PlayerRun playerInputController;

    public GameObject BlockM;
    public GameObject BlockM2;
    public Button uiButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            // Deaktiviere den Spielerinput, wenn der Spieler den Trigger betritt
            if (playerInputController != null)
            {
                playerInputController.DisableInput();
            }
            SimulateButtonPress();

        }
    }

    void SimulateButtonPress()
    {
        if (uiButton.isActiveAndEnabled)
        {
            uiButton.onClick.Invoke(); 
        }
    }

     public void DeActivateObject()
    {
        if (BlockM != null)
        {
            BlockM.SetActive(false);
            BlockM2.SetActive(false);
        }
    }





}
