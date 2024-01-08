using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone1 : MonoBehaviour
{
    // Referenz auf das Skript, das den Spielerinput steuert
    public PlayerRun playerInputController;

    public GameObject spawnPrefab;



    public GameObject BlockBM;
     public GameObject InputHelp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            // Deaktiviere den Spielerinput, wenn der Spieler den Trigger betritt
            if (playerInputController != null)
            {
                playerInputController.DisableInput();
            }
            DeActivateObject();
            

        }
    }

     public void DeActivateObject()
    {
        if (BlockBM != null)
        {
            BlockBM.SetActive(false);
            InputHelp.SetActive(false); // Aktiviert das GameObject
        }
    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            // Aktiviere den Spielerinput, wenn der Spieler den Trigger verlässt
//            if (playerInputController != null)
//            {
//                playerInputController.EnableInput();
//            }
//        }
//    }





}
