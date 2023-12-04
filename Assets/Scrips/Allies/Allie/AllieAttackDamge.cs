using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllieAttackDamge : MonoBehaviour
{
    public int damage;
  void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        Enemy health = hitInfo.GetComponent<Enemy>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

       
    }
}
