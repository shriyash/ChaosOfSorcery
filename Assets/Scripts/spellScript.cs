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
        spellGameData.allSpellsInPool.Add(gameObject.name);
        playerSelected = false;
        enemySelected = false;
        lastTurnCount = spellGameData.turnCounter; 
    }

    // Update is called once per frame
    void Update()
    {   
        //Enemy has made their move
        //Decision time much begin
        if(lastTurnCount != spellGameData.turnCounter)
        {
            if ( (playerSelected == true) & (enemySelected == true) ){
                Debug.Log("They're the same! " + gameObject.name);
                //Blocks player from clicking on another spells while dice game is ongoing
                gameObject.SetActive(false);
                //Launches dice game
                diceGameScript diceScript = GameObject.Find("SetUpDiceGame").GetComponent<diceGameScript>();
                diceScript.SetUpDiceGame();
            }
            else if ((playerSelected == true)){
                Debug.Log("Player selected " + gameObject.name);

            }
            else if ((enemySelected == true)){
                Debug.Log("Enemy selected " + gameObject.name);
            }
            else {
                //Nothing happens
            }
        }

        //Increment lastTurnCount to match with global turnCounter
        lastTurnCount = spellGameData.turnCounter;

        /*check if turn counter is changed
            //if playerSelected and enemeySelect = true, call diceGame() in diceGameScript
            //else if player is true, call moveSpell() to player
            //else if enemy is true, call moveSpell() to enemy
            //else stay in place
        check if allSpells is empty
        */
    }

    // public void ClickText(){
    //     //How we access a child
    //     //Test case
    //     Debug.Log("clicked " + gameObject.transform.GetChild(0).gameObject.name);
    // }

    //Activates when player presses a spell button
    public void playerButtonPressed(){
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
        enemySelected = selected;
    }

}
