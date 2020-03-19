using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDefenseScript : MonoBehaviour
{
    public static AIDefenseScript ai;
    List<GameObject> openTiles;

    void Awake()
    {
        ai = this;
        openTiles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeTurn() 
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Open Tile")) 
        {
            openTiles.Add(go);
        }

        if (openTiles.Count == 0)
        {
            //End mini-game
        }
        else 
        {
            DecisionMaker().GetComponent<tileScript>().SelectTile();
        }
    }

    public GameObject DecisionMaker() 
    {
        //Check if there are any winning moves
        return openTiles.ToArray()[Random.Range(0, openTiles.Count)];
    }
}
