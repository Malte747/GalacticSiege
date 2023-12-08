using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public float maxRage = 100;
    public float rage = 0f;
    public RageAnzeige rageBar;
    public float fillSpeed = 1.0f;

    public Transform spawnPoint;
    public GameObject Boxer;
    public GameObject Kind;
    public Image UpgradeReady;
     public Image UpgradedFlame;
    [SerializeField] private bool ragebarUpgraded = false;

    private List<Renderer> objectRenderers = new List<Renderer>();
    private List<Color> originalColors = new List<Color>();

    void Start()
    {
        
        rageBar.SetRage(rage);

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            objectRenderers.Add(renderer);
            originalColors.Add(renderer.material.color);
        }

       
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

            if (ragebarUpgraded == false && rage >= 40)
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
        fillSpeed = 1.5f;
         Color newColo = UpgradedFlame.color;
        newColo.a = 1f;
        UpgradedFlame.color = newColo;
    }



    public void SummonBoxer(int costBoxer)
    {
        if(costBoxer <= rage)
        {
            rage -= costBoxer;
            rageBar.SetRage(rage);
            SpawnBoxer();
        }
    }

    public void SpawnBoxer()
    {
        if (Boxer != null && spawnPoint != null)
        {
            Instantiate(Boxer, spawnPoint.position, spawnPoint.rotation);
        }
    }



      public void SummonKind(int costKind)
    {
        if(costKind <= rage)
        {
            rage -= costKind;
            rageBar.SetRage(rage);
            SpawnKind();
        }
    }

    public void SpawnKind()
    {
        if (Kind != null && spawnPoint != null)
        {
            Instantiate(Kind, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
