using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour_Ufo : MonoBehaviour
{
 #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public int patrolDestination;
    public Transform[] patrolPoints;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool walk = true;
    public bool cool = true;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private RaycastHit2D stand;
    private GameObject target;
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    public bool inRange; //Check if Player is in range
    public bool cooling; //Check if Enemy is cooling after attack
    
    
    #endregion

    void Awake()
    {
        walk = true;
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        if (cooling && cool)
        {
            cool = false;
            Invoke("Cooldown", 9.3f);
            return;
        }

        hit = Physics2D.Raycast(rayCast.position, Vector2.left, attackDistance, raycastMask);
        stand = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
        RaycastDebugger();

        if (stand.collider != null && stand.collider.CompareTag("Player"))
        {
            walk = false;
            
        }
        else if(attackMode == false)
        {
            walk = true;
        }
        //When Player is detected
        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
            Attack();
            inRange = true;

        }

        else if(walk == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            
        }
    }
    public void Schuss()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void Attack()
    {
        
        attackMode = true;
        cooling = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
        walk = false;
        
    }

    void Cooldown()
    {
        

        if (cooling && attackMode)
        {
            StopAttack();
           
            anim.SetBool("Attack", false);
            anim.SetBool("canWalk", true);
            walk = true;
            cool = true;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

}
