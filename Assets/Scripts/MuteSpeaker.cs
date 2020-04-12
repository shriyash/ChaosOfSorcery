using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSpeaker : MonoBehaviour
{
    AudioSource a;
    public void Start()
    {
        a = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (MuteChecker.muteChecker.isMuted)
        {
            a.volume = 0;
        }
        else 
        {
            a.volume = 0.6f;
        }
    }
}
