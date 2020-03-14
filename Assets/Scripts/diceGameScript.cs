using UnityEngine;
using UnityEngine.UI;

public class diceGameScript : MonoBehaviour
{
    public  GameObject playerInput;
    public  GameObject enemyInput;
    public  GameObject result;

    public Text playerText;

    public Text enemyText;

    private int enemyValue;

    public Text diceVariable;

    // Start is called before the first frame update
    void Start()
    {
        //playerText = playerInput.GetComponentInChildren<Text>();
        hideUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideUI(){
        playerInput.SetActive(false);
        enemyInput.SetActive(false);
        result.SetActive(false);
        enemyText.text = "Enter guess..";
        // I just want to clear the gosh darn text from the player
        // InputField field = playerText.GetComponentInParent(typeof(InputField)) as InputField;
        // field.text = "";
        diceVariable.text = "#";
    }

    public void showUI(){
        playerInput.SetActive(true);
        enemyInput.SetActive(true);
        result.SetActive(true);
    }

    /*
    Dice game script; 
    Will be called once user inputs their value
    Will include
        - taking input from playerInput value
        - comparing to AI value
        - rolling dice/generating random number
        - conditionals for various outcomes
    */
    public void SetUpDiceGame() {
        //Shows input blocks
        Debug.Log("showUI");
        showUI();
        //Generates AI's dice value
        enemyValue = AICombatScript.ai.AIDiceGuess();
    }

    //Begun once user inputs text
    public void DiceGame(){
        Debug.Log("Dice game");
        //Display enemy's result
        enemyText.text = enemyValue.ToString();      

        //Call rollDice() and retrieve value
        int diceResult = rollDice();

        //Show dice result
        diceVariable.text = diceResult.ToString();

        //Parse player input for comparisons
        int playerTextII = int.Parse(playerText.text);

        //Handle conditions
        //Player wins; call moveSpell to player slot
        if (playerTextII == diceResult){
            Debug.Log("Player wins");
            spellGameData.dataInstance.spellObjectStore.setPlayerSelected(false);
            spellGameData.dataInstance.spellObjectStore.setEnemySelected(false);
            spellGameData.dataInstance.spellObjectStore.moveSpell();
            spellGameData.dataInstance.spellObjectStore.transform.parent.gameObject.SetActive(true);
            hideUI();
        }
        //Enemy wins; call moveSpell to enemy Slot
        else if (enemyValue == diceResult){
            Debug.Log("Enemy wins");
            spellGameData.dataInstance.spellObjectStore.moveSpell();
            spellGameData.dataInstance.spellObjectStore.setPlayerSelected(false);
            spellGameData.dataInstance.spellObjectStore.setEnemySelected(false);
            spellGameData.dataInstance.spellObjectStore.transform.parent.gameObject.SetActive(true);
            hideUI();
        }
        else { //If no one wins, we move on to the next round
            Debug.Log("No one wins");
            //Reshow spell selection object
            spellGameData.dataInstance.spellObjectStore.transform.parent.gameObject.SetActive(true);
            //Take away playerSelected and enemySelected from spell
            spellGameData.dataInstance.spellObjectStore.setPlayerSelected(false);
            spellGameData.dataInstance.spellObjectStore.setEnemySelected(false);
            //Hide the UI
            hideUI();
        }

    }

    //Dice roll method
    public int rollDice(){
        Debug.Log("roll dice");
        int resultDice = Random.Range(1,7);
        return resultDice;
    }

}
