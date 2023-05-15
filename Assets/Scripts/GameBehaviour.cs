using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public static float winConditionPercentage = 90.00f;
    public GameObject gameScene, menuScene, winningScene, settingsScene, creditsScene, sceneBackground, backButton;
    public static float demolitionPercentage;
    public static int fallenBricks = 0;
    public static bool finishedContruction = false;
    public static bool gameOver = false;
    public static bool gameStarted = false;
    public static bool reset = false;
    private bool onMenu = true;
    // Start is called before the first frame update
    void Start()
    {
        activateBackground();
    }

    // Update is called once per frame
    void Update()
    {
        if (onMenu)
        {
            backButton.SetActive(false);
        }
        if (reset)
        {
            BallLauncher.ballsThrown = 0;
            demolitionPercentage = 0f;
            fallenBricks = 0;
        }
        else
        {
            if (finishedContruction)
            {
                {
                    demolitionPercentage = ((float)fallenBricks / (float)TowerGenerator.total);
                    if (demolitionPercentage >= ((float)winConditionPercentage / 100))
                    {
                        gameOver = true;
                        gameScene.SetActive(false);
                        audioSource.Play();
                        winningScene.SetActive(true);
                        return;
                    }
                }

            }
        }

    }

    public void initiateGameUI()
    {
        menuScene.SetActive(false);
        onMenu = false;
        sceneBackground.SetActive(false);
        gameScene.SetActive(true);
    }

    public void initiateSettingsUI()
    {
        menuScene.SetActive(false);
        backButton.SetActive(true);
        onMenu = false;
        sceneBackground.SetActive(true);
        settingsScene.SetActive(true);
    }


    public void initiateCreditsUI()
    {
        menuScene.SetActive(false);
        backButton.SetActive(true);
        onMenu = false;
        sceneBackground.SetActive(true);
        creditsScene.SetActive(true);
    }

    public void deactivateBackground()
    {
        sceneBackground.SetActive(false);
    }

    public void activateBackground()
    {
        sceneBackground.SetActive(true);
    }

    public void setOnMenu()
    {
        onMenu = true;
    }

    public static void setWinConditionPercentage(float value)
    {
        winConditionPercentage = value;
    }

    public static void setFinishedConstruction(bool value)
    {
        finishedContruction = value;
    }
    public void setScore(bool value)
    {
        reset = value;
    }
}
