using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Go to main screen from Game.Gameover screen on tap.

public class GameOver : MonoBehaviour
{
    public Animator transitionAnimator;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetTouch(0).phase == TouchPhase.Began))
                && GameManager.gameHasEnded == true)
            {
                StartCoroutine(LoadMainScene());
            }
        }
 
    }

    IEnumerator LoadMainScene()
    {
        transitionAnimator.SetTrigger("game_end");
        yield return new WaitForSeconds(1f);
        RestartGame();
    }


    private void RestartGame()
    {
            GameManager.gameHasEnded = false;
            SceneManager.LoadScene(0);                
    }
}
