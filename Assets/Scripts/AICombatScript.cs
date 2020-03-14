using UnityEngine;
using UnityEngine.UI;

public class AICombatScript
{
    private static int spellSelection;
    private static int diceGuess;

    //Function for having the AI make their spell choice
    public static void AISpellChoice(){
        //Select a random spell choice between 0 and 5 inclusive
        spellSelection = Random.Range(0, 6);

        //Check if value will give us a valid spell
        while (spellSelection > spellGameData.dataInstance.allSpellsInPool.Count - 1){
            spellSelection = Random.Range(0, 6);
        }

        //Get name of spellContainer that the AI selected
        string spellName = spellGameData.dataInstance.allSpellsInPool[spellSelection];
       
        //Get the actual spellContainer object itself 
        GameObject spell = GameObject.Find(spellName);
        Debug.Log("AI spell selection: " + spellName);
        spellScript spellObject = spell.GetComponent<spellScript>();

        //Store spellContainer object into spellGameData
        spellGameData.dataInstance.spellObjectStore = spellObject;
        
        //Set enemySelected to true
        spellObject.setEnemySelected(true);

        //Increment turn counter in spellGameData to signify new round of activity
        spellGameData.dataInstance.turnCounter++;

    }

    //Gets AI's guess for the dice game
    public static int AIDiceGuess(){
        Debug.Log("AI guess");
        diceGuess = Random.Range(1,7);
        return diceGuess;
    }
}
