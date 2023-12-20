using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltBar : MonoBehaviour
{
    public float maxPoints = 100;
    public float points = 0f;
    public UltAnzeige ultBar;
    public float fillSpeed = 0.5f;

    private float costUlt = 100;
    public List<Transform> firePoints;
    public GameObject bulletPrefab;

    public Animator anima;
    public Animator animat;
    public Image UltReady;


    private List<Renderer> objectRenderers = new List<Renderer>();
    private List<Color> originalColors = new List<Color>();
     private Animator anim;
     private bool ReadySound = false;
     private AudioManager audioManager;



 void Start()
    {
        
        ultBar.SetPoints(points);
        anim = GameObject.Find("Richards_teile").GetComponent<Animator>();

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            objectRenderers.Add(renderer);
            originalColors.Add(renderer.material.color);
        }

         audioManager = FindObjectOfType<AudioManager>();
       
    }

        public void Update()
    {
          
            float newRage = Mathf.Clamp(points + fillSpeed * Time.deltaTime, 0, maxPoints);
            if (newRage != points)
            {
                points = newRage;
                ultBar.SetPoints(points);
                
            }

         if (Input.GetKeyDown(KeyCode.Q))
        {
            SummonUlt();
        }

        if(points == 100f)
        {
            UltReadySound();
            anima.SetBool("Full", true);
            animat.SetBool("Q", true);

            Color newColor = UltReady.color;
            newColor.a = 1f;
            UltReady.color = newColor;
            }
        else
        {
                Color newColor = UltReady.color;
                    newColor.a = 0f;
                    UltReady.color = newColor;
        }


    }

    void UltReadySound()
    {
        if(ReadySound == false)
        {
            FindObjectOfType<AudioManager>().Play("UltReady");
            ReadySound = true;
        }
    }

     public void SummonUlt()
    {
        if(costUlt <= points)
        {
            FindObjectOfType<AudioManager>().Play("UltActivate");
            Invoke("UltExplosionSound", 1.5f);
            points -= costUlt;
            ultBar.SetPoints(points);
            anim.SetTrigger("Ult");
            anima.SetBool("Full", false);
            animat.SetBool("Q", false);
             foreach (Transform firePoint in firePoints)
            {
                Ult(firePoint);
            }
             if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }

        // Wähle einen zufälligen Sound aus
        string[] possibleSounds = { "RUlt1", "RUlt2", "RUlt3"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        // Spiee den zufällig ausgewählten Sound über den AudioManager ab
        audioManager.Play(selectedSound);
        }
        ReadySound = false;
    }

    void UltExplosionSound()
    {
        FindObjectOfType<AudioManager>().Play("UltExplosion");
    }

    void Ult(Transform firePoint)
    {
             Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);    
    }

    public void PointsAdd(float ultpoints)
    {
        if(points <= 100f && points >= 4f)
        {
        points += ultpoints;
        }
    }



}
