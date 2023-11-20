using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject drop;
    public Transform spawnPosition;

    // Update is called once per frame
    void Update()
    {
           int randomNumber = Random.Range(1, 101);
    if(randomNumber <= 100)
    {
        Instantiate(drop, spawnPosition.position, Quaternion.identity);
    }  
    }
}
