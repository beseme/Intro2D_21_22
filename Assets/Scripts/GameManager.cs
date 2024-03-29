using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player;

    public AudioSource BGM = null;
    
    private void Awake()
    {
        Instance = this;
    }

    public void PauseBGM()
    {
        if (BGM.isPlaying)
        {
            BGM.Pause();
        }
        else
        {
            BGM.UnPause();
        }
    }
}
