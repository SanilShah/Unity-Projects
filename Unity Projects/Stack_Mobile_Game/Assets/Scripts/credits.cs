using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Go from Credits screen to Main Menu
public class credits : MonoBehaviour
{
    public Animator transitionAnimator;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetTouch(0).phase == TouchPhase.Began)))
            {
                StartCoroutine(LoadMainScene());
            }
        }

    }

    IEnumerator LoadMainScene()
    {
        transitionAnimator.SetTrigger("credits_end");
        yield return new WaitForSeconds(1f);
        RestartGame();
    }


    private void RestartGame()
    {
        GameManager.gameHasEnded = false;
        SceneManager.LoadScene(0);
    }
}
