using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float firerate;
    float nextfire;
    private Animator anim;
    


 void Awake()
    {
       
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
           
        }
      

      
    }

    void Shoot ()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);    
            anim.SetTrigger("Reloading");
        }
        
        
        
    }


}
