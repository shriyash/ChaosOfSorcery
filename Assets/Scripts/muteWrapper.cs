using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteWrapper : MonoBehaviour
{
    bool isMuted = false;
    void Update()
    {
        MuteChecker.muteChecker.isMuted = isMuted;
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
    }
}
