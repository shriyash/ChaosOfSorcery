using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spellScript : MonoBehaviour
{
    private bool playerSelected;
    private bool enemySelected;
    private int lastTurnCount;
    private bool assigned;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Step 1: Start");
        spellGameData.dataInstance.allSpellsInPool.Add(gameObject.name);
        playerSelected = false;
        enemySelected = false;
        lastTurnCount = spellGameData.dataInstance.turnCounter; 
    }

    // Update is called once per frame
    void Update()
    {   
        //Check if all spells have been removed; if so, exit to new scene
        if (spellGameData.dataInstance.allSpellsInPool.Count == 0){
            //exit script
        }

        //Enemy has made their move
        //Decision time much begin
        if(lastTurnCount != spellGameData.dataInstance.turnCounter)
        {
            if ( (playerSelected == true) && (enemySelected == true) ){
                playerSelected = false;
                enemySelected = false;
                //Debug.Log("Both selected same spell");
                //Blocks player from clicking on another spells while dice game is ongoing
                gameObject.transform.parent.gameObject.SetActive(false);
                //Launches dice game
                diceGameScript diceScript = GameObject.Find("diceGame").GetComponent<diceGameScript>();
                diceScript.SetUpDiceGame();
                
            }
            else if ((playerSelected == true)){
                //Debug.Log("Only Player selected spell");

            }
            else if ((enemySelected == true)){
                //Debug.Log("Only Enemy selected spell");
            }
            else {
                //Nothing happens
                //Debug.Log("else Update");
            }
        }
        //Increment lastTurnCount to match with global turnCounter
        lastTurnCount = spellGameData.dataInstance.turnCounter; 
    }

    // public void ClickText(){
    //     //How we access a child
    //     //Test case
    //     Debug.Log("clicked " + gameObject.transform.GetChild(0).gameObject.name);
    // }

    //Activates when player presses a spell button
    public void playerButtonPressed(){
        //Debug.Log("step playerButtonPressed");
        playerSelected = true;
        //Call enemy selection in AICombatScript
        AICombatScript.AISpellChoice();
    }

    //move spell to respective slot
    //remove gameobject name from list
    public void moveSpell(){

    }

    //Necessary to ensure encapsulation, but still set enemySelected boolean in AICombatScript
    public void setEnemySelected(bool selected){
        //Debug.Log("setEnemy active");
        enemySelected = selected;
    }

    public void setPlayerSelected(bool selected){
        //Debug.Log("setPlayer active");
        playerSelected = selected;
    }

}
