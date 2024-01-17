using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 
    public float FollowSpeed = 2f;
    public float yoffset =1f;
    public float xoffset = 1f;
    public Transform target;
    public bool gamerunning = true;

    public Transform endpos; // Das Ziel, zu dem sich die Kamera bewegen soll
    public float smoothSpeed = 0.125f; // Die Geschwindigkeit, mit der sich die Kamera bewegen soll
    public float endposXPosition = 10f; // Die X-Koordinate, zu der sich die Kamera bewegen soll

    public float startSize = 4.54f; // Anfangsgröße
    public float targetSize = 8.3f; // Zielgröße
    public float duration = 2.0f; // Dauer der Änderung

    private float elapsedTime = 0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if(gamerunning)
        {
        Vector3 newPos = new Vector3(target.position.x + xoffset,target.position.y + yoffset,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
        
        }
        else if (endpos != null && !gamerunning)
        {
        Vector3 desiredPosition = new Vector3(endposXPosition, endpos.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Berechne den prozentualen Fortschritt der Änderung
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Verändere allmählich die Größe der Kamera-Projektion
            float newSize = Mathf.Lerp(startSize, targetSize, t);
            mainCamera.orthographicSize = newSize;
        }
        }
    }

   
 public void FinalLevel()
    {
        Debug.Log("1111");

            Debug.Log("2222");
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        float newSize = Mathf.Lerp(targetSize, startSize, t);
        mainCamera.orthographicSize = newSize;
        
    }

}
