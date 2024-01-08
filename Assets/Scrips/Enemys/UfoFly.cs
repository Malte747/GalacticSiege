using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoFly : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void End()
    {
   
        if (animator != null)
        {
            animator.SetTrigger("Win");
        }
    }
}
