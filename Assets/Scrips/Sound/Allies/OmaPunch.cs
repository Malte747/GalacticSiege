using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmaPunch : MonoBehaviour
{
   public void Hit()
   {
    FindObjectOfType<AudioManager>().Play("OmaPunch");
   }
}
