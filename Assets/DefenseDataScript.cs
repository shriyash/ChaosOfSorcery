using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefenseDataScript : MonoBehaviour
{
    //Keeps track of the row count for vertical rows
    private static int vertRowCount = 0;
    public static DefenseDataScript defenseData;
    public bool gameDone = false;
    //Array to hold values for selected and unselected tiles
    //0 means unselected tile
    private static int[,] tileArray = {
        {0, 0, 0},
        {0, 0, 0},
        {0, 0, 0},
    };

    private void Awake()
    {
        defenseData = this;
    }

    public void CheckLose()
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
                defenseData.EndGame(false);
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
        defenseData.EndGame(false);
    }

    public static void checkDiagonal(int corner){
        //Check diagonal for win
        if (tileArray[1,1] == 0){
            return;
        }
        else {
            if (((tileArray[2, 0] == 1) && (corner == 2)) || ((tileArray[2,2]== 1) && (corner == 0))) {
                defenseData.EndGame(false);
            }
        }
    }

    public void EndGame(bool playerWon) 
    {
        gameDone = true;
        StartCoroutine("EndGameCoroutine", playerWon);
    }

    public IEnumerator EndGameCoroutine(bool playerWon) 
    {
        Text endText = GameObject.Find("End Text").GetComponent<Text>();
        if (playerWon) 
        {
            endText.text = "You defended yourself against your opponent! You get a HEALTH BONUS!";
        }

        else
        {
            endText.text = "Your opponent mounted a stronger defense! The enemy gets a HEALTH BONUS!";
        }

        yield return new WaitForSeconds(4f);
        //Change to next scene
        SceneManager.LoadScene("SampleScene");
    }

}
