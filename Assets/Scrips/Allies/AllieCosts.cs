using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AllieCosts : MonoBehaviour
{
 public int costBoxer = 10;
  public int costKind = 20;
   public int costOma = 25;
   public int costAnimeGirl = 35;
   public int costRageUpgrade = 40;
   public int costRageUpgrade2 = 60;
   public int costRageUpgrade3 = 80;
   private bool cooldown = false;
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
    if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            RageBar.SummonAnimeGirl(costAnimeGirl);
        }

    if (Input.GetKeyDown(KeyCode.E) && !RageBar.ragebarUpgraded)
        {
            RageBar.RageUpgrade(costRageUpgrade);
            cooldown = true;
            Invoke("SetCooldown", 0.1f);
        }
    if (Input.GetKeyDown(KeyCode.E) && cooldown == false && !RageBar.ragebarUpgraded2)
        {
            RageBar.RageUpgrade2(costRageUpgrade2);
            cooldown = true;
            Invoke("SetCooldown", 0.1f);
        }
    if (Input.GetKeyDown(KeyCode.E) && cooldown == false)
        {
            RageBar.RageUpgrade3(costRageUpgrade3);
        }

        
}
    	
    public void SetCooldown()
    {
        cooldown = false;
    }









}
