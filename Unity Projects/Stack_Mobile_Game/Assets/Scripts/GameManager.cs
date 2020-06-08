using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

// Load Game Over UI in game scene on finishing the game.

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded = false;
    public float restartdelay = 0.5f;


    public static GameObject levelUI;
    private static GameObject gameOverText;

    public void Awake()
    {
        levelUI = GameObject.FindGameObjectWithTag("UI");
        gameOverText = levelUI.transform.GetChild(0).gameObject;
    }

    public static void CompleteLevel()
    {       
        gameOverText.SetActive(true);
    }

    public static void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            Time.timeScale = 1;
            StackMovement.newStack.SetActive(false);
            StackMovement.lastStack.GetComponent<BoxCollider>().enabled = false;
        }
    }
}

