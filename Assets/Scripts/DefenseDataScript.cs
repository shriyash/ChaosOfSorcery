using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDataScript : MonoBehaviour
{
    //Keeps track of the row count for vertical rows
    private static int vertRowCount = 0;
    //Array to hold values for selected and unselected tiles
    //0 means unselected tile
    private static int[,] tileArray = {
        {0, 0, 0},
        {0, 0, 0},
        {0, 0, 0},
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This seems massively inefficent, but we'll see
        //May be able to optimize via an iterative approach?
        //do the checks for three in a row. Means player has lost. AI will automatically admit defeat.
        for (int x=0; x < tileArray.GetLength(0); x++){
            for (int y=0; y < tileArray.GetLength(1); y++){
                if(tileArray[x,y] == 1){
                    vertRowCount++;

                    //Only need to check verticals when on top row
                    if(x==0){
                        Debug.Log("x was 0");
                        checkHorizontal(y);

                        if(y==0 || y==2){
                            checkDiagonal(y);
                        }
                    }
                    
                }
            }
            if (vertRowCount == 3){
                Debug.Log("Player looses");
                //Would need to stop AI from picking and end update
            }
            else {
                vertRowCount = 0;
            }
        }
    }

    public static void ChangeTile(int row, int column){
        tileArray[row-1, column-1] = 1;
        Debug.Log("tileArray changed at " + (row-1) + ", " +  (column-1));
    }

    public static void checkHorizontal(int column){
        //Checks column for match
        for (int x=1; x < 3; x++){
            Debug.Log("Checking tile " + x + ", " + column);
            Debug.Log("Value is " + tileArray[x, column]);
            if (tileArray[x, column] == 0){
                Debug.Log("check failed");
                return;
            }
        }
        //Need to put exit condition here
        Debug.Log("Player has lost in horizontal");
    }

    public static void checkDiagonal(int corner){
        //Check diagonal for win
        if (tileArray[1,1] == 0){
            return;
        }
        else {
            if (((tileArray[2, 0] == 1) && (corner == 2)) || ((tileArray[2,2]== 1) && (corner == 0))) {
                Debug.Log("Player lost on diag");
            }
        }
    }
}
