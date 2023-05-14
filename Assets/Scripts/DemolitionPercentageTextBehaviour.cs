using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemolitionPercentageTextBehaviour : MonoBehaviour
{
    public Text scoreText, congratulationsText;
    private float scoreCounter;

    void Start()
    {

    }

    void Update()
    {
        scoreCounter = GameBehaviour.demolitionPercentage*100;  
        scoreText.text = ": "+scoreCounter.ToString() + "%";  
        congratulationsText.text = "causing "+scoreCounter.ToString()+"% damage to the tower";
        if (GameBehaviour.gameOver)
        {
            scoreText.text = " ";  
        }
    }
}
