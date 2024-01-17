using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UfoDeath : MonoBehaviour
{
   public int maxHealth = 100;
   public int health;

   public HealthBar HealthBar;
    public GameObject UIHeathBarDeactivate;
     public GameObject UIUltBarDeactivate;
     public GameObject UIRageBarDeactivate;
     public GameObject UISummonDeactivate;
     MainMenu _mainmenu;
     AudioManager Audio;
     public Animator animator;
    public bool todlaser = false;


    void Start()
    {
        health = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
        _mainmenu = GameObject.Find("LevelManager").GetComponent<MainMenu>();
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
        Invoke("FindMyStuff", 6f);
        
       
    }

    public void FindMyStuff()
    {
        UISummonDeactivate = GameObject.Find("Summon");
        UIHeathBarDeactivate = GameObject.Find("Health bar4");
        UIUltBarDeactivate = GameObject.Find("Ultimative");
        UIRageBarDeactivate = GameObject.Find("RageBar");
    }
    
   public void TakeDamage (int damage)
   {
    health -= damage;

    if (health <= 0)
    {
        Die();
        todlaser = true;
   }
    HealthBar.SetHealth(health);
   }

   void Die ()
   {
    
    UIHeathBarDeactivate.SetActive(false);
    UIRageBarDeactivate.SetActive(false);
    UISummonDeactivate.SetActive(false);
    UIUltBarDeactivate.SetActive(false);

        animator.SetTrigger("Death");
        Invoke("WinSound", 5f);
        Invoke("Win", 5f);
        Invoke("Death", 5f);
        Audio.StopPlaying("BossFight");
        Audio.Play("UfoDeath");
        


    
   }

    public void Win()
    {
        _mainmenu.LevelCounter();
        DeactivateLevel();
        ActivateGameObjects();
    }

    public void ActivateGameObjects()
    {
                // Holen Sie sich alle GameObjects in der aktuellen Szene
        GameObject[] allGameObjects = SceneManager.GetSceneByBuildIndex(2).GetRootGameObjects();

        // Deaktiviere jedes GameObject
        foreach (GameObject go in allGameObjects)
        {
            go.SetActive(true);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

        void DeactivateLevel()
    {

        GameObject[] allGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();


        foreach (GameObject go in allGameObjects)
        {
            go.SetActive(false);
        }
        
    }

        public void WinSound()
    {
        Audio.Play("Victory");
    }

    public void Death()
    {
        Destroy(gameObject);
    }




}

