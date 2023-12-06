using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonButtons : MonoBehaviour
{
    public Image image; // Das Image-Element, dessen Farbe geändert werden soll
    public KeyCode keyToGrayOut = KeyCode.Alpha1; // Die Taste, die gedrückt wird, um das Image zu färben
    public float grayDuration = 1.0f; // Die Zeit, für die das Image grau gefärbt wird

    private Color originalColor; // Die ursprüngliche Farbe des Images

    void Start()
    {
        if (image != null)
        {
            originalColor = image.color; // Speichert die ursprüngliche Farbe des Images
        }
        else
        {
            Debug.LogError("Image nicht zugewiesen!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToGrayOut))
        {
            StartCoroutine(GrayOutCoroutine());
        }
    }

    IEnumerator GrayOutCoroutine()
    {
        image.color = Color.gray; // Setzt die Farbe des Images auf grau

        yield return new WaitForSeconds(grayDuration); // Wartet für die angegebene Zeit

        image.color = originalColor; // Setzt die Farbe des Images auf die ursprüngliche Farbe zurück
    }
}
