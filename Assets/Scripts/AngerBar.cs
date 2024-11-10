using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBar : MonoBehaviour
{
    //분노 게이지바 클래스

    public Slider slider;
    public Image fillImage;
    public Gradient gradient;

    // Start is called before the first frame update

    public void SetValue(int value)
    {
        slider.value = value;
        fillImage.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Start()
    {
        slider.maxValue = 20;
        slider.value = 0;
        fillImage.color = gradient.Evaluate(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
