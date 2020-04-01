using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackGameScript : MonoBehaviour
{
    public Text pHealth;

    public Text eHealth;

    public Text pSpellSel;

    public Text eSpellSel;

    public Text winner;

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

        if (BattleData.battleDatInstance.playerHealth == 0){
            winner.text = "Enemy wins!";
        }
        else if (BattleData.battleDatInstance.enemyHealth == 0){
            winner.text = "Player wins!";
        }
        
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

            if (playerSpellLevel > enemySpellLevel){
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
                //Nothing happens?
            }
        }
        else if (playerSpellType == SpellHolder.SPELL_TYPE.FIRE){
            if (enemySpellType == SpellHolder.SPELL_TYPE.ICE){
                //Player wins
                BattleData.battleDatInstance.enemyHealth -= levelThreeDamage;
            }
            else {
                //Player looses
                BattleData.battleDatInstance.playerHealth -= levelThreeDamage;
            }
        }
        else if (playerSpellType == SpellHolder.SPELL_TYPE.ICE){
            if (enemySpellType == SpellHolder.SPELL_TYPE.LIGHTNING){
                //Player wins
                BattleData.battleDatInstance.enemyHealth -= levelThreeDamage;
            }
            else {
                //Player looses
                BattleData.battleDatInstance.playerHealth -= levelThreeDamage;
            }
        }
        //Player type is lightening
        else {
            if (enemySpellType == SpellHolder.SPELL_TYPE.FIRE){
                //Player wins
                BattleData.battleDatInstance.enemyHealth -= levelThreeDamage;
            }
            else {
                //Player looses
                BattleData.battleDatInstance.playerHealth -= levelThreeDamage;
            }
        }
        //Should update health text
        spellLaunched++;
    }
}
