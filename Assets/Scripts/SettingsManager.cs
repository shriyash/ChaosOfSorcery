using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    GameObject settings;
    private void Start()
    {
        settings = GameObject.Find("settings");
        CloseMenu();
    }
    public void OpenMenu() 
    {
        settings.SetActive(true);
    }

    public void CloseMenu()
    {
        settings.SetActive(false);
    }
}
