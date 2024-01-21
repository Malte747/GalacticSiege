using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAnimation : MonoBehaviour
{
  public float newYPosition = 5f; // Die neue Y-Position, die du erreichen möchtest.
  public float newXPosition = 0f;
  
    void Start()
    {
       
        // Hole die aktuelle Position des GameObjects.
        Vector3 currentPosition = transform.position;
        

        // Ändere nur die Y-Koordinate der Position.
        currentPosition.y = currentPosition.y + newYPosition;
        currentPosition.x = currentPosition.x + newXPosition;

        // Setze die Position des GameObjects auf die aktualisierte Position.
        transform.position = currentPosition;

        Destroy(gameObject, 6.5f);
    }


}
