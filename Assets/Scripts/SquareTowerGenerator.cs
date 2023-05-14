using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareTowerGenerator : TowerGenerator
{
    public InputField widthField, heightField;
    // Start is called before the first frame update
    void Start()
    {
        towerCard = GameObject.Find("SquareTowerCard");
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        generation(width, width, height);
    }

    public void setWidthFromInputField()
    {
        setWidth(int.Parse(widthField.text));
    }

    public void setHeightFromInputField()
    {
        setHeight(int.Parse(heightField.text));
    }

}
