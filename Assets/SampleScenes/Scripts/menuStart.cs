using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuStart : MonoBehaviour
{
    public void changemenuscene (string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
