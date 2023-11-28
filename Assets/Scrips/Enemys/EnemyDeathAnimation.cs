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

        // Alternativ: Setze nur die Y-Koordinate der Position ohne Zwischenspeicherung.
        // transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

         public void Update()
    {
            Destroy(gameObject, 2f);
    } 
}
