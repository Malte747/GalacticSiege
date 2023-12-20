using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4Sound : MonoBehaviour
{
   public void Hit()
   {
    FindObjectOfType<AudioManager>().Play("Monster4Attack");
   }
}
