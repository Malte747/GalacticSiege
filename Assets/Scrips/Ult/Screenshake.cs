using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    public float shakeDuration = 0.1f; // Dauer des Bildschirm-Shakes
    public float shakeAmount = 0.1f; // Intensität des Bildschirm-Shakes

    private Vector3 originalPos; // Ursprüngliche Position der Kamera
    private Transform cameraTransform; // Kamera-Transform, das geschüttelt werden soll

    void Start()
    {
        cameraTransform = Camera.main.transform; // Automatische Identifizierung der Hauptkamera
        originalPos = cameraTransform.localPosition;
        ShakeScreen();
    }

    public void ShakeScreen()
    {
        if (cameraTransform != null)
        {
            InvokeRepeating("StartShaking", 0f, 0.01f);
            Invoke("StopShaking", shakeDuration);
        }
    }

    void StartShaking()
    {
        float shakeX = Random.Range(-1f, 1f) * shakeAmount;
        float shakeY = Random.Range(-1f, 1f) * shakeAmount;

        Vector3 newPos = originalPos + new Vector3(shakeX, shakeY, 0);
        cameraTransform.localPosition = newPos;
    }

    void StopShaking()
    {
        CancelInvoke("StartShaking");
        cameraTransform.localPosition = originalPos;
    }
}