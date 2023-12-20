using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3Explosion : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Monster3Explosion");
    }

}
