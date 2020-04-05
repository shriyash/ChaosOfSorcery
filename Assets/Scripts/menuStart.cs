using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuStart : MonoBehaviour
{
    public void changeMenuScene(string sceneName)
    {
        Application.LoadLevel (sceneName);
    }
}
