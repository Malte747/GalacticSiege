using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allie_Behaviour : MonoBehaviour
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
    public GameObject[] projectiles;
     AllieHealth allieHealth;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    public bool inRange; //Check if Player is in range
    public bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    AllieAttackDamge AllieAttackDamge;
    #endregion

    void Awake()
    {
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
        allieHealth = GetComponent<AllieHealth>();
    }

    void Update()
    {
        if (allieHealth.Dead == true)
        {
            anim.SetTrigger("Death");
        }

        if (cooling)
        {
            Cooldown();
            return;
        }

        hit = Physics2D.Raycast(rayCast.position, Vector2.right, attackDistance, raycastMask);
        RaycastDebugger();


        //When Player is detected
        if (hit.collider != null && allieHealth.Dead == false)
        {
            target = hit.collider.gameObject;
            Attack();
            inRange = true;

        }

        else if (allieHealth.Dead == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
        }

       
    }

    public void Schuss()
    {
     if (projectiles.Length > 0)
        {
            int randomIndex = Random.Range(0, projectiles.Length);
            GameObject selectedProjectile = projectiles[randomIndex];

            Instantiate(selectedProjectile, firePoint.position, firePoint.rotation);
        }
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        cooling = true;

       
        anim.SetTrigger("Attack");
    }


    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            StopAttack();
            timer = intTimer;
            anim.SetTrigger("canWalk");
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
            Debug.DrawRay(rayCast.position, Vector2.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.right * rayCastLength, Color.green);
        }
    }
    
    public void OmaRastet()
    {
        AllieAttackDamge = GameObject.Find("hitboxOma").GetComponent<AllieAttackDamge>();
        moveSpeed = 2.5f; 
        AllieAttackDamge.MoreDmgOma();
       
    }


}

