using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    bool isOpen = true;
    Renderer colorRenderer;

    private Color regularColor, selectedColor;
    public int row, column;

    public Material white;
    private Material original;


    // Start is called before the first frame update
    void Start()
    {
        colorRenderer = this.gameObject.GetComponent<Renderer>();
        original = colorRenderer.material;
        colorRenderer.material = white;
    }

    //Changes the color of the box on hover
    void OnMouseEnter(){
        if (isOpen)
        {
            //Can change the color here
            colorRenderer.material = original;
        }
    }

    //Resets color to original color
    void OnMouseExit(){
        if (isOpen) 
        { 
             colorRenderer.material = white;
        }
    }

    private void OnMouseDown()
    {
        SelectTile();
        DefenseDataScript.defenseData.CheckLose();
        AIDefenseScript.ai.TakeTurn();
    }

    public void SelectTile() 
    {
        colorRenderer.material = original;
        tag = "Untagged";
        isOpen = false;
        DefenseDataScript.ChangeTile(this.row, this.column);
    }
}
