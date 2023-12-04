using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_behaviour : MonoBehaviour
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
    #endregion

    void Awake()
    {
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        if (cooling)
        {
            Cooldown();
            return;
        }

        hit = Physics2D.Raycast(rayCast.position, Vector2.left, attackDistance, raycastMask);
        RaycastDebugger();


        //When Player is detected
        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
            Attack();
            inRange = true;

        }

        else
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
        timer = intTimer;
        attackMode = true;
        cooling = true;

        anim.SetBool("canWalk", false);
        anim.SetTrigger("Attack");
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            StopAttack();
            timer = intTimer;
            anim.SetBool("canWalk", true);
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
