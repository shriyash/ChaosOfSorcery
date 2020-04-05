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

    private int[,] initialPositions = {{-292, 0}, {280, 0}};
    private int increment = 32;

    public int spellLevel;
    public SpellHolder.SPELL_TYPE spellType;

    // Start is called before the first frame update
    void Start()
    {
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

        if (spellGameData.dataInstance.allSpellsInPool.Contains(gameObject)) //These lines disable selected spells
        {
            GetComponentInChildren<Button>().interactable = true;
        }
        else 
        {
            GetComponentInChildren<Button>().interactable = false;
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

                moveSpell("player");
                //Debug.Log("Only Player selected spell");

            }
            else if ((enemySelected == true)){
                moveSpell("enemy");
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

    //Activates when player presses a spell button
    public void playerButtonPressed(){
        if (!spellGameData.dataInstance.diceGamePlaying) //Make sure the player can't press any buttons while the game is playing
        {
            setPlayerSelected(true);
            //Debug.Log("step playerButtonPressed");
            playerSelected = true;
            //Call enemy selection in AICombatScript
            AICombatScript.ai.AISpellChoice();
        }
    }

    //move spell to respective slot
    //remove gameobject name from list
    //May need to use "anchored position" attribute
    public void moveSpell(string holder){
        RectTransform spellMover = GetComponent<RectTransform>();
        Debug.Log("Move called for " + this.gameObject);

        if (holder.Equals("player")){
            Debug.Log("Player position: " + initialPositions[0,0] + ", " +  (initialPositions[0,1]-(increment*spellGameData.dataInstance.spellsForPlayer.Count)));
            spellMover.anchoredPosition = new Vector2(initialPositions[0,0], initialPositions[0,1]-(increment*spellGameData.dataInstance.spellsForPlayer.Count));
            spellGameData.dataInstance.spellsForPlayer.Add(this.gameObject);
            BattleData.battleDatInstance.playerSpells.Add(new SpellHolder(spellType, spellLevel));
        }  
        else {
            Debug.Log("Enemy position: " + initialPositions[1,0] + ", " +  (initialPositions[1,1]-(increment*spellGameData.dataInstance.spellsForEnemy.Count)));
            spellMover.anchoredPosition = new Vector2(initialPositions[1,0], initialPositions[1,1]-(increment*spellGameData.dataInstance.spellsForEnemy.Count));
            spellGameData.dataInstance.spellsForEnemy.Add(this.gameObject);
            BattleData.battleDatInstance.enemySpells.Add(new SpellHolder(spellType, spellLevel));
        } 
        spellGameData.dataInstance.allSpellsInPool.Remove(this.gameObject); //Removes this spell from the active pool; comment out this line to allow repeat selections
        playerSelected = false;
        enemySelected = false;
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
