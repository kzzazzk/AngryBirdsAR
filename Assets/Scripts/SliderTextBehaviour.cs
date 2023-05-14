using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTextBehaviour : MonoBehaviour
{
    public Text textSliderValue;
    public Slider sliderUI ;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textSliderValue.text = sliderUI.value + "%"; 
        GameBehaviour.setWinConditionPercentage(sliderUI.value);
    }


}
