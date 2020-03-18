using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{

    Renderer colorRenderer;
    private Color regularColor;


    // Start is called before the first frame update
    void Start()
    {
       regularColor = this.gameObject.GetComponent<Renderer>().material.GetColor("_Color");;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Changes the color of the box on hover
    void OnMouseEnter(){
        colorRenderer = this.gameObject.GetComponent<Renderer>();
        //Can change the color here
        colorRenderer.material.SetColor("_Color", Color.yellow);
    }

    //Resets color to original color
    void OnMouseExit(){
        colorRenderer.material.SetColor("_Color", regularColor);
    }
}
