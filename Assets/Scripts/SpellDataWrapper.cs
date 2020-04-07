using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDataWrapper : MonoBehaviour
{
    public int level;
    public SpellHolder.SPELL_TYPE spellType;
    static int count = 0;

    public void Start()
    {
        count++;
    }

    public void MakeSelection() 
    {
        if (attackGameScript.isDone)
        {
            GetComponent<Button>().interactable = false;
        }
        else {
            count--;
            SpellHolder thisSpell = new SpellHolder(spellType, level);
            BattleData.battleDatInstance.playerSpells.Remove(thisSpell);
            attackGameScript.attackDataInstance.playerSelectedSpell = thisSpell;
            attackGameScript.attackDataInstance.MakeEnemySelection();
            GetComponent<Button>().interactable = false; 
        }
    }
}
