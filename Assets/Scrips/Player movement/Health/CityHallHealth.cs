using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityHallHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public HealthBar HealthBar;
    public GameObject deathEffect;

    public float duration = 0.1f; // Dauer der Farbänderung in Sekunden
    public Color targetColor = Color.red; // Zielfarbe
    private List<Renderer> objectRenderers = new List<Renderer>();
    private List<Color> originalColors = new List<Color>();
    private AudioManager audioManager;

    
    void Start()
    {
        health = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
          foreach (Renderer renderer in renderers)
        {
            objectRenderers.Add(renderer);
            originalColors.Add(renderer.material.color);
        }
        audioManager = FindObjectOfType<AudioManager>();
    }

  
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(ChangeColorRoutine());
        if(health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            DeactivateLevel();
            ActivateGameObjects();
        }
        HealthBar.SetHealth(health);
    }

        public void ActivateGameObjects()
    {
                // Holen Sie sich alle GameObjects in der aktuellen Szene
        GameObject[] allGameObjects = SceneManager.GetSceneByBuildIndex(1).GetRootGameObjects();

        // Deaktiviere jedes GameObject
        foreach (GameObject go in allGameObjects)
        {
            go.SetActive(true);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        audioManager.StopPlaying("Victory");
        audioManager.StopPlaying("ThemeMenu");
        audioManager.StopPlaying("Theme");
        audioManager.StopPlaying("Theme2");
        audioManager.StopPlaying("Theme3");
        audioManager.StopPlaying("Theme4");
        audioManager.StopPlaying("Theme5");
        audioManager.Play("Defeat1");
    }

        void DeactivateLevel()
    {

        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();


        foreach (GameObject go in allGameObjects)
        {
            go.SetActive(false);
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
