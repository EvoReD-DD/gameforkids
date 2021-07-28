using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider sliderValue;
    [SerializeField] GameObject ZubAnimationController;
    float bonus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SliderInc();
    }

    void SliderInc()
    {
        bonus = ZubAnimationController.GetComponent<ZubAnimationController>().bonus;
        sliderValue.value = bonus;
    }
}
