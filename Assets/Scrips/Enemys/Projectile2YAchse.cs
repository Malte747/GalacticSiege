using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2YAchse : MonoBehaviour
{
    public float moveSpeed = 0.25f; // Die Geschwindigkeit, mit der sich das GameObject bewegen soll
    public float yOffset = 1.1f; // Die Höhe, um die das GameObject verschoben werden soll

    void Start()
    {
        StartCoroutine(MoveObjectOverTime());
    }

    IEnumerator MoveObjectOverTime()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y + yOffset, startPosition.z);

        float elapsedTime = 0f;

        while (elapsedTime < 6.2f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / 1.5f);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.position = targetPosition; // Stellt sicher, dass das Objekt genau auf der Zielposition endet
    }
}
