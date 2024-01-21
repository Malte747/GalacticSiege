using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public float maxRage = 70f;
    public float rage = 5f;
    public RageAnzeige rageBar;
    public float fillSpeed = 1.5f;

    public Transform spawnPoint;
    public GameObject Boxer;
    public GameObject Kind;
    public GameObject Oma;
    public GameObject AnimeGirl;
    public Image UpgradeReady;
     public Image UpgradedFlame;
     public Image UpgradedFlame2;
     public Image UpgradedFlame3;
    public bool ragebarUpgraded = false;
    public bool ragebarUpgraded2 = false;
    public bool ragebarUpgraded3 = false;

    private List<Renderer> objectRenderers = new List<Renderer>();
    private List<Color> originalColors = new List<Color>();
    private AudioManager audioManager;
    

    void Start()
    {
        rageBar.SetMaxRage(maxRage);
        rageBar.SetRage(rage);
        rageBar.SetRageCount(rage);

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
          
            float newRage = Mathf.Clamp(rage + fillSpeed * Time.deltaTime, 0, maxRage);
            if (newRage != rage)
            {
                rage = newRage;
                rageBar.SetRage(rage);
                rageBar.SetRageCount(rage);
            }

            if (ragebarUpgraded == false && rage >= 40 || ragebarUpgraded2 == false && rage >= 60 || ragebarUpgraded3 == false && rage >= 80)
            {
                    Color newColor = UpgradeReady.color;
                    newColor.a = 1f;
                    UpgradeReady.color = newColor;
            }
            else{
                Color newColor = UpgradeReady.color;
                    newColor.a = 0f;
                    UpgradeReady.color = newColor;
            }
        
    }

    public void RageUpgrade(int costRageUpgrade)
    {
        if (ragebarUpgraded == false && costRageUpgrade <= rage)
        {
            rage -= costRageUpgrade;
            rageBar.SetRage(rage);
            UpgradeRagebar();
            ragebarUpgraded = true;
        }
    }

    public void UpgradeRagebar()
    {
        fillSpeed = 2f;
        maxRage = 90f;
        rageBar.SetMaxRage(maxRage);
        rageBar.Upgrade1();
         Color newColo = UpgradedFlame.color;
        newColo.a = 1f;
        UpgradedFlame.color = newColo;

        if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }
        
        string[] possibleSounds = { "Upgrade1", "Upgrade2"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        
        audioManager.Play(selectedSound);

        }

    public void RageUpgrade2(int costRageUpgrade2)
    {
        if (ragebarUpgraded == true && ragebarUpgraded2 == false && costRageUpgrade2 <= rage)
        {
            rage -= costRageUpgrade2;
            rageBar.SetRage(rage);
            ragebarUpgraded2 = true;
            UpgradeRagebar2();
            
        }
    }

    public void UpgradeRagebar2()
    {
        fillSpeed = 3f;
        maxRage = 110f;
        rageBar.SetMaxRage(maxRage);
        rageBar.Upgrade2();
         Color newColo = UpgradedFlame2.color;
        newColo.a = 1f;
        UpgradedFlame2.color = newColo;

        if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }
        
        string[] possibleSounds = { "Upgrade1", "Upgrade2"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        
        audioManager.Play(selectedSound);
    }

    public void RageUpgrade3(int costRageUpgrade3)
    {
        if (ragebarUpgraded == true && ragebarUpgraded2 == true && ragebarUpgraded3 == false && costRageUpgrade3 <= rage)
        {
            rage -= costRageUpgrade3;
            rageBar.SetRage(rage);
            ragebarUpgraded3 = true;
            UpgradeRagebar3();
            
        }
    }

    public void UpgradeRagebar3()
    {
        fillSpeed = 3.5f;
        maxRage = 130f;
        rageBar.SetMaxRage(maxRage);
        rageBar.Upgrade2();
         Color newColo = UpgradedFlame3.color;
        newColo.a = 1f;
        UpgradedFlame3.color = newColo;

        if (audioManager == null)
        {
            Debug.LogError("AudioManager nicht gefunden!");
            return;
        }
        
        string[] possibleSounds = { "Upgrade1", "Upgrade2"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        
        audioManager.Play(selectedSound);
    }




    public void TutorialSetFill()
    {
        fillSpeed = 1.5f;
    }

       public void TutorialSetFillNull()
    {
        fillSpeed = 0f;
    }



    public void SummonBoxer(int costBoxer)
    {
        if(costBoxer <= rage)
        {
            rage -= costBoxer;
            rageBar.SetRage(rage);
            SpawnBoxer();
        }
        else
        {
            audioManager.Play("NoRage");
        }
    }

    public void SpawnBoxer()
    {
        if (Boxer != null && spawnPoint != null)
        {
            Instantiate(Boxer, spawnPoint.position, spawnPoint.rotation);
            rageBar.SetRageCount(rage);
            BoxerSound();
            
        }
    }

    void BoxerSound()
        {
        
        string[] possibleSounds = { "Boxer1", "Boxer2", "Boxer3", "Boxer4"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        audioManager.Play(selectedSound);
        }



      public void SummonKind(int costKind)
    {
        if(costKind <= rage)
        {
            rage -= costKind;
            rageBar.SetRage(rage);
            SpawnKind();
        }
        else
        {
            audioManager.Play("NoRage");
        }
    }

    public void SpawnKind()
    {
        if (Kind != null && spawnPoint != null)
        {
            Instantiate(Kind, spawnPoint.position, spawnPoint.rotation);
            KindSound();
        }
       
    }

    void KindSound()
        {
        
        string[] possibleSounds = { "Kind1", "Kind2", "Kind3", "Kind4", "Kind5", "Kind6", "Kind7"};
        int randomIndex = Random.Range(0, possibleSounds.Length);
        string selectedSound = possibleSounds[randomIndex];

        audioManager.Play(selectedSound);
        }



      public void SummonOma(int costOma)
    {
        if(costOma <= rage)
        {
            rage -= costOma;
            rageBar.SetRage(rage);
            SpawnOma();
        }
        else
        {
            audioManager.Play("NoRage");
        }
    }

    public void SpawnOma()
    {
        if (Oma != null && spawnPoint != null)
        {
            Instantiate(Oma, spawnPoint.position, spawnPoint.rotation);
            OmaSound();
        }
    }

    void OmaSound()
        {
        
            string[] possibleSounds = { "Oma1", "Oma2", "Oma3", "Oma4"};
            int randomIndex = Random.Range(0, possibleSounds.Length);
            string selectedSound = possibleSounds[randomIndex];

            audioManager.Play(selectedSound);
        }



public void SummonAnimeGirl(int costAnimeGirl)
    {
        if(costAnimeGirl <= rage)
        {
            rage -= costAnimeGirl;
            rageBar.SetRage(rage);
            SpawnAnimeGirl();
        }
        else
        {
            audioManager.Play("NoRage");
        }
    }

public void SpawnAnimeGirl()
    {
        if (AnimeGirl != null && spawnPoint != null)
        {
            Instantiate(AnimeGirl, spawnPoint.position, spawnPoint.rotation);
            AnimeGirlSound();
        }
    }

void AnimeGirlSound()
        {
        
            string[] possibleSounds = { "Anime1", "Anime2", "Anime3", "Anime4", "Anime5", "Anime6", "Anime7", "Anime8", "Anime9", "Anime10", "Anime11", "Anime12", "Anime13"};
            int randomIndex = Random.Range(0, possibleSounds.Length);
            string selectedSound = possibleSounds[randomIndex];

            audioManager.Play(selectedSound);
        }
}
