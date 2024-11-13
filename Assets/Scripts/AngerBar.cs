using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBar : MonoBehaviour
{
    //분노 게이지바 클래스

    public Slider slider;
    public Image fillImage;

    // Start is called before the first frame update

    public void SetValue(int value)
    {
        slider.value = value;
    }

    void Start()
    {
        slider.maxValue = 10;
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
