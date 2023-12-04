using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBar : MonoBehaviour
{
    public float maxRage = 100;
    [SerializeField] private float rage = 0f;
    public RageAnzeige rageBar;
    public float fillSpeed = 1.0f;

    public Transform spawnPoint;
    public GameObject Boxer;





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
            }
        
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
}
