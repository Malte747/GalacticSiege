using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllieCosts : MonoBehaviour
{
 public int costBoxer = 10;
  public int costKind = 20;
   public int costOma = 25;
   public int costRageUpgrade = 40;
 RageBar RageBar;

 void Start()
 {
     RageBar = GetComponent<RageBar>();
 }
 

 
void Update()
{
    if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RageBar.SummonBoxer(costBoxer);
        }

    if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RageBar.SummonKind(costKind);
        }

    if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RageBar.SummonOma(costOma);
        }

    if (Input.GetKeyDown(KeyCode.E))
        {
            RageBar.RageUpgrade(costRageUpgrade);
        }
}










}
