using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UltAnzeige : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
  
   
   public void SetMaxPoints(float points)
    {
        slider.maxValue = points;
        slider.value = points;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetPoints(float points)
    {
        slider.value = points;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }




}
