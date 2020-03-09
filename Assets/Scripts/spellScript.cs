using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellScript : MonoBehaviour
{
    public static List<string> allSpells = new List<>(); //Basically, make a new list to hold all spells
    private bool playerSelected;
    private bool enemySelected;
    private int lastTurnCount;
    private bool assigned;

    // Start is called before the first frame update
    void Start()
    {
        allSpells.add(gameObject.name);
        playerSelected = false;
        enemySelected = false;
        lastTurnCount = spellGameData.turnCounter;
    }

    // Update is called once per frame
    void Update()
    {   
        /*check if turn counter is changed
            //if playerSelected and enemeySelect = true, call diceGame() in diceGameScript
            //else if player is true, call moveSpell() to player
            //else if enemy is true, call moveSpell() to enemy
            //else stay in place
        check if allSpells is empty
        */
    }

    //Implement listener for button

    //move spell to respective slot
    //remove gameobject name from list
    public void moveSpell(){

    }
}
