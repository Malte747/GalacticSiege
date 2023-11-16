using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public PlayerRun playerMovement;

private void OnTriggerEnter2D(Collider2D other)
{
    

{
    if(other.CompareTag("Player"))
    {

        playerHealth.TakeDamage(damage);
    }
}


}
}
