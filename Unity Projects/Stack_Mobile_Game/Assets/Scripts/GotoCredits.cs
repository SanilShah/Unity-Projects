using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoCredits : MonoBehaviour
{
    public Animator transitionAnim;

    public void LoadCredits()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        Load();
    }

    private void Load()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Loading Credits...");
    }
}
