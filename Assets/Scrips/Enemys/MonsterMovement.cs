using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

  

    // Update is called once per frame
    void Update()
    {
        if(patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
        }
    }
}
