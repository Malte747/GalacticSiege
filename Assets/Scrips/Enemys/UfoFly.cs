using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoFly : MonoBehaviour
{
    public Animator animator;
    AudioManager Audio;
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
 
        Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Audio.StopPlaying("Defeat1");
        Audio.StopPlaying("ThemeMenu");
        Audio.StopPlaying("Theme");
        Audio.StopPlaying("Theme2");
        Audio.StopPlaying("Theme3");
        Audio.StopPlaying("Theme4");
        Audio.StopPlaying("Theme5");
        Audio.Play("Ufo");
        Invoke("WinSound", 4f);
        
    }

    public void FakeEnd()
    {
        Destroy(gameObject);
    }

    public void WinSound()
    {
        Audio.Play("Victory");
    }
}
