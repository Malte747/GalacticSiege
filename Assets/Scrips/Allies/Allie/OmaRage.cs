using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmaRage : MonoBehaviour
{

    AllieHealth AllieHealth;
    Allie_Behaviour Allie_Behaviour;
    public bool RageAn = false;
    public Color desiredColor = Color.red;



   
    void Start()
    {
        AllieHealth = GetComponent<AllieHealth>();
        Allie_Behaviour = GetComponent<Allie_Behaviour>();
    }

  
    void FixedUpdate()
    {
        if(AllieHealth.health <= 129 && RageAn == false)
        {
           RageAn = true;
           ChangeColorOfChildren(transform);
           Allie_Behaviour.OmaRastet();
        }
    }
    void ChangeColorOfChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                childRenderer.material.color = desiredColor; 
            }

            
            if (child.childCount > 0)
            {
                ChangeColorOfChildren(child);
            }
        }
    }

}
