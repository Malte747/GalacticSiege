using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RageAnzeige : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TMP_Text LevelText;
   


 
    public void SetMaxRage(float rage)
    {
        slider.maxValue = rage;
        slider.value = rage;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetRage(float rage)
    {
        slider.value = rage;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetRageCount(float rage)
    {
        int roundedValue = Mathf.RoundToInt(rage);
        LevelText.text = "" + roundedValue;
    }




}
