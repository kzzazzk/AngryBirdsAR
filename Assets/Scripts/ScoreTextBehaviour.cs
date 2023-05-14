using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextBehaviour : MonoBehaviour
{
    public Text demolitionPercentageText, congratulationsDPerText, ballsThrownText, congratulationsBallsThrownText;
    private float demolitionPercentage;
    private int ballsThrown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        demolitionPercentage = GameBehaviour.demolitionPercentage * 100;
        demolitionPercentageText.text = ": " + demolitionPercentage.ToString() + "%";
        congratulationsDPerText.text = "causing " + demolitionPercentage.ToString() + "% damage to the tower";
        ballsThrown = BallLauncher.ballsThrown;
        ballsThrownText.text = ": " + ballsThrown.ToString();
        congratulationsBallsThrownText.text = "You have thrown " + ballsThrown.ToString() + " balls";

        if (GameBehaviour.gameOver)
        {
            demolitionPercentageText.text = " ";
            ballsThrownText.text = " ";

        }

    }
}
