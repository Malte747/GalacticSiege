using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Hit : MonoBehaviour
{
   public void Hit()
   {
    FindObjectOfType<AudioManager>().Play("Monster1hit");
   }
}
