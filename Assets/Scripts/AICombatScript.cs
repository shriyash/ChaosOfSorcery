using UnityEngine;
using UnityEngine.UI;

public class AICombatScript : MonoBehaviour
{
    public static AICombatScript ai;
    private int spellSelection;
    private int diceGuess;

    private void Awake()
    {
        ai = this;
    }

    //Function for having the AI make their spell choice
    public void AISpellChoice(){
        Debug.Log(spellGameData.dataInstance.allSpellsInPool.Count);
        //Select a random spell choice between 0 and 5 inclusive
        spellSelection = Random.Range(0, spellGameData.dataInstance.allSpellsInPool.Count - 1);
        //Get name of spellContainer that the AI selected
        GameObject spell = spellGameData.dataInstance.allSpellsInPool.ToArray()[spellSelection];
        string spellName = spell.name;

        //Get spellScript from spell
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
    public int AIDiceGuess(){
        //Debug.Log("AI guess");
        diceGuess = Random.Range(1,7);
        return diceGuess;
    }
}
