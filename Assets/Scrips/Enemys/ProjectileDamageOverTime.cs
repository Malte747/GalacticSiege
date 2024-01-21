using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageOverTime : MonoBehaviour
{
    public int damage = 10;
    [SerializeField] private List<GameObject> objectsInZone = new List<GameObject>();
    private bool damageCooldown = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject currentObject = other.gameObject;
        if (!objectsInZone.Contains(currentObject))
        {
            objectsInZone.Add(currentObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject currentObject = other.gameObject;
        if (objectsInZone.Contains(currentObject))
        {
            objectsInZone.Remove(currentObject);
        }
    }

    private void Update()
    {
        if (!damageCooldown)
        {
            StartCoroutine(ApplyDamageOverTime());
        }
    }

    IEnumerator ApplyDamageOverTime()
    {
        damageCooldown = true;

        foreach (GameObject currentObject in objectsInZone)
        {
            ApplyDamage(currentObject);
        }

        yield return new WaitForSeconds(1f);

        damageCooldown = false;
    }

    private void ApplyDamage(GameObject currentObject)
    {
        PlayerHealth health = currentObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        CityHallHealth Leben = currentObject.GetComponent<CityHallHealth>();
        if (Leben != null)
        {
            Leben.TakeDamage(damage);
        }

        AllieHealth allieHealth = currentObject.GetComponent<AllieHealth>();
        if (allieHealth != null)
        {
            allieHealth.TakeDamage(damage);
        }
    }
}







