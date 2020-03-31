using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDataWrapper : MonoBehaviour
{
    public int level;
    public SpellHolder.SPELL_TYPE spellType;

    public void MakeSelection() 
    {
        attackGameScript.attackDataInstance.playerSelectedSpell = new SpellHolder(spellType, level);
        attackGameScript.attackDataInstance.MakeEnemySelection();
    }
}
