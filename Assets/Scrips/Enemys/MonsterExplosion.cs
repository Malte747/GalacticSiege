using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterExplosion : MonoBehaviour
{
    public int damage;

    public GameObject deathEffect;

private void OnCollisionEnter2D(Collision2D collision)
{
            PlayerRun playerMovement = collision.gameObject.GetComponent<PlayerRun>();
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            CityHallHealth cityHallHeath = collision.gameObject.GetComponent<CityHallHealth>();

    if(collision.gameObject.tag == "Player")
    {
        playerMovement.KBCounter = playerMovement.KBTotalTime;
        if(collision.transform.position.x <= transform.position.x)
        {
            playerMovement.KnockFromRight = true;
        } 
        if(collision.transform.position.x >= transform.position.x)
        {
            playerMovement.KnockFromRight = false;
        } 
        playerHealth.TakeDamage(damage);
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
     if(collision.gameObject.tag == "City Hall")
    {
        
        cityHallHeath.TakeDamage(damage);
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
}
