using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class attackGameScript : MonoBehaviour
{
    public static bool isDone = false;
    public Text pHealth;

    public Text eHealth;

    public Text pSpellSel;

    public Text eSpellSel;

    public Text winner;
    public Text finalWinner;

    private int spellLaunched = 0;
    private int spellLaunchedWatch = 0;

    private int levelOneDamage = 3;
    private int levelTwoDamage = 5;
    private int levelThreeDamage = 10;
    public SpellHolder playerSelectedSpell, enemySelectedSpell;

    public static attackGameScript attackDataInstance;
    // Start is called before the first frame update
    // There is an instance of the BattleData attached to the eventSystem. WE'll need to remove it before the final product is released
    void Start()
    {
        finalWinner = GameObject.Find("Final Winner").GetComponent<Text>();
        //Get health for enemy and player
        eHealth.text = BattleData.battleDatInstance.enemyHealth.ToString();
        pHealth.text = BattleData.battleDatInstance.playerHealth.ToString();
       
        attackDataInstance = this;
        if (BattleData.battleDatInstance != null) 
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Spell RPS")) 
            {
                go.SetActive(false);
                foreach (SpellHolder s in BattleData.battleDatInstance.playerSpells)
                {
                    if (go.GetComponent<SpellDataWrapper>().level == s.GetSpellLevel() && go.GetComponent<SpellDataWrapper>().spellType == s.GetSpellType()) 
                    {
                        go.SetActive(true);
                    }
                }
            }
        }
    }

    public void MakeEnemySelection() 
    {
        if (BattleData.battleDatInstance != null && BattleData.battleDatInstance.enemySpells != null) 
        {
            if (BattleData.battleDatInstance.enemySpells.Count > 0)
            {
                enemySelectedSpell = BattleData.battleDatInstance.enemySpells.ToArray()[Random.Range(0, BattleData.battleDatInstance.enemySpells.Count)];
                BattleData.battleDatInstance.enemySpells.Remove(enemySelectedSpell);
                compareSpells();
            }
            else 
            {
                Debug.Log("player wins");
            }
        }
    }

    void Update()
    {
        if (spellLaunched != spellLaunchedWatch){
            pHealth.text = BattleData.battleDatInstance.playerHealth.ToString();
            eHealth.text = BattleData.battleDatInstance.enemyHealth.ToString();
            spellLaunchedWatch++;
        }

        if (BattleData.battleDatInstance.playerHealth <= 0) {
            BattleData.battleDatInstance.playerHealth = 0;
            finalWinner.text = "Enemy WINS!";
            StartCoroutine("GoToTitle");
        }
        else if (BattleData.battleDatInstance.enemyHealth <= 0) {
            BattleData.battleDatInstance.enemyHealth = 0;
            finalWinner.text = "Player WINS!";
            StartCoroutine("GoToTitle");
        }
        else if (BattleData.battleDatInstance.enemySpells.Count == 0)
        {
            if (BattleData.battleDatInstance.playerSpells.Count == 0)
            {
                finalWinner.text = "Both you and enemy ran out of spells! It's a DRAW!";
                StartCoroutine("GoToTitle");
            }
            else
            {
                finalWinner.text = "The enemy ran out of spells! You WIN!";
                StartCoroutine("GoToTitle");
            }
        }
        else if (BattleData.battleDatInstance.playerSpells.Count == 0) 
        {
            finalWinner.text = "You ran out of spells! You LOSE!";
            StartCoroutine("GoToTitle");
        }

        eHealth.text = BattleData.battleDatInstance.enemyHealth.ToString();
        pHealth.text = BattleData.battleDatInstance.playerHealth.ToString();

        if(enemySelectedSpell != null)
            eSpellSel.text = enemySelectedSpell.ToString();

        if (playerSelectedSpell != null)
            pSpellSel.text = playerSelectedSpell.ToString();
    }

    public void compareSpells(){
        //Lightening beats fire
        //Fire beats ice
        //Ice beats lightening

        //Compare same ices
        SpellHolder.SPELL_TYPE playerSpellType = playerSelectedSpell.GetSpellType();
        SpellHolder.SPELL_TYPE enemySpellType = enemySelectedSpell.GetSpellType();
        int playerSpellLevel = playerSelectedSpell.GetSpellLevel();
        int enemySpellLevel = enemySelectedSpell.GetSpellLevel();

        //Assumes the spell types are equal
        if (playerSpellType == enemySpellType){

            if (playerSpellLevel > enemySpellLevel)
            {
                winner.text = "Winner: YOU!";
                Debug.Log("winner is you");

                if (playerSpellLevel == 1){
                    BattleData.battleDatInstance.enemyHealth -= levelOneDamage;
                }
                else if (playerSpellLevel == 2){
                    BattleData.battleDatInstance.enemyHealth -= levelTwoDamage;
                }
                else {
                    BattleData.battleDatInstance.enemyHealth -= levelThreeDamage;
                }
            }
            else if (playerSpellLevel < enemySpellLevel){
                winner.text = "Winner: ENEMY!";
                Debug.Log("winner is they");

                if (enemySpellLevel == 1){
                    BattleData.battleDatInstance.playerHealth -= levelOneDamage;
                }
                else if (enemySpellLevel == 2){
                    BattleData.battleDatInstance.playerHealth -= levelTwoDamage;
                }
                else {
                    BattleData.battleDatInstance.playerHealth -= levelThreeDamage;
                }

            }
            else {
                winner.text = "Winner: DRAW!";
                Debug.Log("winner is we");
            }
        }
        else if (playerSpellType == SpellHolder.SPELL_TYPE.FIRE){
            if (enemySpellType == SpellHolder.SPELL_TYPE.ICE){
                //Player wins
                BattleData.battleDatInstance.enemyHealth -= levelThreeDamage;
                winner.text = "Winner: YOU!";
            }
            else {
                //Player looses
                winner.text = "Winner: ENEMY!";
                BattleData.battleDatInstance.playerHealth -= levelThreeDamage;
            }
        }
        else if (playerSpellType == SpellHolder.SPELL_TYPE.ICE){
            if (enemySpellType == SpellHolder.SPELL_TYPE.LIGHTNING){
                //Player wins
                winner.text = "Winner: YOU!";
                BattleData.battleDatInstance.enemyHealth -= levelThreeDamage;
            }
            else {
                //Player looses
                winner.text = "Winner: ENEMY!";
                BattleData.battleDatInstance.playerHealth -= levelThreeDamage;
            }
        }
        //Player type is lightening
        else {
            if (enemySpellType == SpellHolder.SPELL_TYPE.FIRE){
                //Player wins
                winner.text = "Winner: YOU!";
                BattleData.battleDatInstance.enemyHealth -= levelThreeDamage;
            }
            else {
                //Player looses
                winner.text = "Winner: ENEMY!";
                BattleData.battleDatInstance.playerHealth -= levelThreeDamage;
            }
        }
        //Should update health text
        spellLaunched++;
    }

    IEnumerator GoToTitle() 
    {
        isDone = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Start");
    }
}
