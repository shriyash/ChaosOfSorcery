using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Refernce: https://docs.unity3d.com/ScriptReference/Camera-backgroundColor.html

public class colorChangeScript : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public float duration;

    public Camera cam;

    void Start()
    {
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2, t);
    }
}
