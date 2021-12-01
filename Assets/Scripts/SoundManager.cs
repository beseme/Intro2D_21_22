using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public GameObject SourceObject = null;
    public List<AudioSource> SourceList = new List<AudioSource>();
    public int SourceCount = 5;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        while (SourceCount > 0)
        {
            SourceCount--;
            var source = Instantiate(SourceObject, transform);
            SourceList.Add(source.GetComponent<AudioSource>());
        }
    }

    public void PlayBasic(AudioClip clip, float volume)
    {
        foreach (var source in SourceList)
        {
            if (!source.isPlaying)
            {
                source.PlayOneShot(clip, volume);
                return;
            }
        }
    }
}
