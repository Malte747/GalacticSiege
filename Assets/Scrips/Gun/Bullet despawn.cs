using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletdespawn : MonoBehaviour
{
     public void Update()
    {
            Destroy(gameObject, 2f);
    } 
    
}
