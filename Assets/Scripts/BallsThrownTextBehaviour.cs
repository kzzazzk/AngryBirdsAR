using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class BallsThrownTextBehaviour : MonoBehaviour
{
    public Text scoreText, congratulationsText;
    private float scoreCounter;

    void Start()
    {

    }

    void Update()
    {
        scoreCounter = BallLauncher.ballsThrown;  
        scoreText.text = ": " + scoreCounter.ToString();  
        congratulationsText.text = "You have thrown "+scoreCounter.ToString()+" balls";
        if (GameBehaviour.gameOver)
        {
            scoreText.text = " "; 
        }
    }
}
