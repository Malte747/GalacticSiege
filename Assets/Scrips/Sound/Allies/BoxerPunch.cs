using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerPunch : MonoBehaviour
{    
   public void Hit()
   {
    FindObjectOfType<AudioManager>().Play("BoxerPunch");
   }
}
