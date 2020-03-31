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

    public SpellHolder playerSelectedSpell, enemySelectedSpell;

    public static attackGameScript attackDataInstance;
    // Start is called before the first frame update
    void Start()
    {
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
        
    }
}
