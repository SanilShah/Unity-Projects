using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Play BGM across scenes.
public class DontDestroyBGM : MonoBehaviour
{
    private GameObject BGM;
    public AudioSource BackgroundMusic;

    private void Awake()
    {
        GameObject BGM = GameObject.FindGameObjectWithTag("BGM");
        if ( BGM == null)
        {
            AudioSource CurrentMusic = Instantiate(BackgroundMusic);
            CurrentMusic.Play();
            DontDestroyOnLoad(CurrentMusic);
        }
    }
}
