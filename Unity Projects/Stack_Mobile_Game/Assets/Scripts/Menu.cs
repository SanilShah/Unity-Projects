using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Go from main menu to game on tap.
public class Menu : MonoBehaviour
{
    public Animator transitionAnim;

    void Update()
    {
        if ( Input.touchCount == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetTouch(0).phase == TouchPhase.Began))
                StartCoroutine(LoadScene());
        }
            
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        StartGame();
    }

    private void StartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         Debug.Log("Loading Main Game...");        
    }
}
