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
    public GameObject Border;
    public GameObject Fill;
     public GameObject BG;
   


 
    public void SetMaxRage(float Maxrage)
    {
        slider.maxValue = Maxrage;
        slider.value = Maxrage;

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

    public void Upgrade1()
    {
        RectTransform rectTransform = Border.GetComponent<RectTransform>();
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x + 25.45f, rectTransform.offsetMax.y);

        RectTransform rectTransformFill = Fill.GetComponent<RectTransform>();
        rectTransformFill.offsetMax = new Vector2(rectTransformFill.offsetMax.x + 25.45f, rectTransformFill.offsetMax.y);

        RectTransform rectTransformBG = BG.GetComponent<RectTransform>();
        rectTransformBG.offsetMax = new Vector2(rectTransformBG.offsetMax.x + 26f, rectTransformBG.offsetMax.y);

    }

        public void Upgrade2()
    {
        RectTransform rectTransform = Border.GetComponent<RectTransform>();
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x + 25.45f, rectTransform.offsetMax.y);

        RectTransform rectTransformFill = Fill.GetComponent<RectTransform>();
        rectTransformFill.offsetMax = new Vector2(rectTransformFill.offsetMax.x + 25.45f, rectTransformFill.offsetMax.y);

        RectTransform rectTransformBG = BG.GetComponent<RectTransform>();
        rectTransformBG.offsetMax = new Vector2(rectTransformBG.offsetMax.x + 26f, rectTransformBG.offsetMax.y);
    }

        public void Upgrade3()
    {
        RectTransform rectTransform = Border.GetComponent<RectTransform>();
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x + 25.45f, rectTransform.offsetMax.y);

        RectTransform rectTransformFill = Fill.GetComponent<RectTransform>();
        rectTransformFill.offsetMax = new Vector2(rectTransformFill.offsetMax.x + 25.45f, rectTransformFill.offsetMax.y);

        RectTransform rectTransformBG = BG.GetComponent<RectTransform>();
        rectTransformBG.offsetMax = new Vector2(rectTransformBG.offsetMax.x + 26f, rectTransformBG.offsetMax.y);
    }



}
