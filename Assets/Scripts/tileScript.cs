using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    bool isOpen = true;
    Renderer colorRenderer;
    private Color regularColor, selectedColor;

    // Start is called before the first frame update
    void Start()
    {
        colorRenderer = this.gameObject.GetComponent<Renderer>();
        regularColor = this.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        selectedColor = Color.magenta;
    }

    //Changes the color of the box on hover
    void OnMouseEnter(){
        if (isOpen)
        {
            //Can change the color here
            colorRenderer.material.SetColor("_Color", Color.yellow);
        }
    }

    //Resets color to original color
    void OnMouseExit(){
        if (isOpen) 
        { 
            colorRenderer.material.SetColor("_Color", regularColor); 
        }
    }

    private void OnMouseDown()
    {
        SelectTile();
        AIDefenseScript.ai.TakeTurn();
    }

    public void SelectTile() 
    {
        colorRenderer.material.SetColor("_Color", selectedColor);
        tag = "Untagged";
        isOpen = false;
    }
}
