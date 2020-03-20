using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDefenseScript : MonoBehaviour
{
    public static AIDefenseScript ai;
    List<GameObject> openTiles;

    int[,] posArray = new int[3, 3];

    void Awake()
    {
        ai = this;
    }

    // Update is called once per frame
    public void TakeTurn() 
    {
        int[,] ZERO_ARRAY = new int[7, 7] //-1 is out of bounds, 1 is blocked, 0 is open
        {
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, 1, 1, 1, -1, -1 },
            { -1, -1, 1, 1, 1, -1, -1 },
            { -1, -1, 1, 1, 1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, -1, -1, -1 },
        };

        openTiles = new List<GameObject>();
        posArray = ZERO_ARRAY;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Open Tile")) 
        {
            openTiles.Add(go);
            tileScript ts = go.GetComponent<tileScript>();
            posArray[ts.row + 1, ts.column + 1] = 0;
        }

        if (openTiles.Count == 0)
        {
            //End mini-game
        }
        else 
        {
            DecisionMaker();
        }
    }

    public void DecisionMaker() 
    {
        List<GameObject> goodSpaces = new List<GameObject>();

        //this is bad code do not look :(
        for(int i = 2; i < posArray.GetLength(0) - 1; i++) 
        {
            for (int j = 2; j < posArray.GetLength(1) - 1; j++)
            {
                if (posArray[i, j] == 0)
                {
                    Debug.Log("Good so far");
                    //Check vertical
                    if (
                        (posArray[i - 1, j] == 0 || (posArray[i - 2, j] == 0)) 
                        || (posArray[i + 1, j] == 0 || (posArray[i + 2, j] == 0)) 
                          )
                    {
                        //Check horizontal
                        if (
                        (posArray[i, j - 1] == 0 || (posArray[i, j - 2] == 0))
                        || (posArray[i, j + 1] == 0 || (posArray[i, j] + 2 == 0))
                        )
                        {
                            //Check diagonal if needed
                            if (i == 2 && j == 2)
                            {
                                if (posArray[3, 3] == 0 || posArray[4, 4] == 0)
                                {
                                    goodSpaces.Add(FindByCoordinates(i, j));
                                }
                            }

                            else if (i == 2 && j == 4)
                            {
                                if (posArray[3, 3] == 0 || posArray[4, 3] == 0)
                                {
                                    goodSpaces.Add(FindByCoordinates(i, j));
                                }
                            }

                            else if (i == 4 && j == 2)
                            {
                                if (posArray[3, 3] == 0 || posArray[2, 4] == 0)
                                {
                                    goodSpaces.Add(FindByCoordinates(i, j));
                                }
                            }

                            else if (i == 4 && j == 4)
                            {
                                if (posArray[3, 3] == 0 || posArray[2, 2] == 0)
                                {
                                    goodSpaces.Add(FindByCoordinates(i, j));
                                }
                            }

                            else if (i == 3 && j == 3) 
                            {
                                if ((posArray[2, 2] == 0 || posArray[4, 4] == 0) && (posArray[2, 4] == 0 || posArray[4, 2] == 0)) 
                                {
                                    goodSpaces.Add(FindByCoordinates(i, j));
                                }
                            }

                            else
                            {
                                goodSpaces.Add(FindByCoordinates(i, j));
                            }
                        }
                    }

                }
            }
        }

        //Check if there are any winning moves
        if (goodSpaces.Count > 0)
        {
            GameObject chosenTile = goodSpaces.ToArray()[Random.Range(0, goodSpaces.Count)];
            Debug.Log(chosenTile.name);
            chosenTile.GetComponent<tileScript>().SelectTile();
        }
        else 
        {
            Debug.Log("U R win");
        }
    }

    private GameObject FindByCoordinates(int i, int j) 
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Open Tile")) 
        {
            tileScript ts = go.GetComponent<tileScript>();
            if (ts.row == i -1  && ts.column == j - 1)
            {
                return go;
            }
        }

        return null;
    }
}
