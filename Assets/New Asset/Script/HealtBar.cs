using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    private Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void setMaxHealt(float amount)
    {
        slider.maxValue = amount;
        slider.value = amount;

        fill.color = gradient.Evaluate(1f);
    }

    public void setHealt(float amount)
    {
        slider.value = amount;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
