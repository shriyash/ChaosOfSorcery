using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteChecker : MonoBehaviour
{
    public static MuteChecker muteChecker;
    public bool isMuted = false;

    void Start()
    {
        if (muteChecker == null)
        {
            muteChecker = this;
            DontDestroyOnLoad(this);
        }
        else 
        {
            Destroy(this);
        }
    }

    public void ToggleMute() 
    {
        isMuted = !isMuted;
    }
}
