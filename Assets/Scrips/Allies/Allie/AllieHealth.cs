using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AllieHealth : MonoBehaviour
{
   public int maxHealth = 100;
   public int health;

   public GameObject deathEffect;
   public HealthBar HealthBar;

   public float duration = 0.1f; // Dauer der Farbänderung in Sekunden
    public Color targetColor = Color.red; // Zielfarbe

    private List<Renderer> objectRenderers = new List<Renderer>();
    private List<Color> originalColors = new List<Color>();
   public bool Dead = false;
   

    void Start()
    {
        health = maxHealth;
       // HealthBar.SetMaxHealth(maxHealth);
         Renderer[] renderers = GetComponentsInChildren<Renderer>();
          foreach (Renderer renderer in renderers)
        {
            objectRenderers.Add(renderer);
            originalColors.Add(renderer.material.color);
        }
    }
    
   public void TakeDamage (int damage)
   {
    health -= damage;
    StartCoroutine(ChangeColorRoutine());
    if (health <= 0)
    {
        Dead = true;
        
        //HealthBar.SetHealth(health);
        Destroy(gameObject, 2f);
   } 
   }



     IEnumerator ChangeColorRoutine()
    {
        // Ändere die Farbe aller Renderer auf die Zielfarbe
        foreach (Renderer renderer in objectRenderers)
        {
            renderer.material.color = targetColor;
        }

        // Warte für 'duration' Sekunden
        yield return new WaitForSeconds(duration);

        // Setze alle Renderer auf ihre ursprünglichen Farben zurück
        for (int i = 0; i < objectRenderers.Count; i++)
        {
            objectRenderers[i].material.color = originalColors[i];
        }
    }


}


