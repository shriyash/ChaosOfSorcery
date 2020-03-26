using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class diceGameScript : MonoBehaviour
{
    public  GameObject playerInput;
    public  GameObject enemyInput;
    public  GameObject result;

    public GameObject winner;

    public Text playerText;

    public Text enemyText;

    private int enemyValue;

    public Text diceVariable;

    public Text winnerText;

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
        playerInput.GetComponent<InputField>().text = "";
        playerInput.SetActive(false);
        enemyInput.SetActive(false);
        result.SetActive(false);
        winner.SetActive(false);
        enemyText.text = "Enter guess..";
        diceVariable.text = "#";
        winnerText.text = "Winner";
    }

    public void showUI(){
        playerInput.SetActive(true);
        enemyInput.SetActive(true);
        result.SetActive(true);
        winner.SetActive(true);
    }

    public void SetUpDiceGame() {
        showUI();
        //Generates AI's dice value
        enemyValue = AICombatScript.ai.AIDiceGuess();
    }

    IEnumerator DiceGameCoroutine()
    {
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
            winnerText.text = "Player Wins!";
            yield return new WaitForSeconds(2.0f);
            spellGameData.dataInstance.spellObjectStore.moveSpell("player");
            spellGameData.dataInstance.spellObjectStore.transform.parent.gameObject.SetActive(true);
            hideUI();
        }
        //Enemy wins; call moveSpell to enemy Slot
        else if (enemyValue == diceResult){
            Debug.Log("Enemy wins");
            winnerText.text = "Enemy Wins!";
            yield return new WaitForSeconds(2.0f);
            spellGameData.dataInstance.spellObjectStore.moveSpell("enemy");
            spellGameData.dataInstance.spellObjectStore.transform.parent.gameObject.SetActive(true);
            hideUI();
        }
        else { //If no one wins, we move on to the next round
            Debug.Log("No one wins");
            winnerText.text = "No One Wins!";
            yield return new WaitForSeconds(2.0f);
            //Reshow spell selection object
            spellGameData.dataInstance.spellObjectStore.transform.parent.gameObject.SetActive(true);
            //Take away playerSelected and enemySelected from spell
            //Hide the UI
            hideUI();
        }
    }

    //Begun once user inputs text
    public void DiceGame(){
        StartCoroutine(DiceGameCoroutine());
    }

    //Dice roll method
    public int rollDice(){
        int resultDice = Random.Range(1,7);
        return resultDice;
    }

}
