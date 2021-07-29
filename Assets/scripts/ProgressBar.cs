using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider sliderValue;
    [SerializeField] GameObject CleaningController;
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
        bonus = CleaningController.GetComponent<CleaningController>().bonus;
        sliderValue.value = bonus;
    }
}
