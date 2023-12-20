using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
   public int healing;

   public float despawnTime = 5f;


    void Start()
    {
        Invoke("DespawnObject", 0f + despawnTime);
    }


 void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        PlayerHealth health = hitInfo.gameObject.GetComponent<PlayerHealth>();
        if(hitInfo.gameObject.tag == "Player")
    {
        FindObjectOfType<AudioManager>().Play("Heart");
        health.Heal(healing);

        Destroy(gameObject);
    }
       

    }
 void DespawnObject()
    {
        Destroy(gameObject);
    }


}