using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHolder
{
    int spellLevel;
    SPELL_TYPE spellType;

    public enum SPELL_TYPE 
    {
        ICE = 1, FIRE = 2, LIGHTNING = 3
    }
    
    public SpellHolder(SPELL_TYPE newSpellType, int newLevel) 
    {
        spellType = newSpellType;
        spellLevel = newLevel;
    }

    public string SpellTypeToString() 
    {
        switch ((int)spellType) 
        {
            case 1:
                return "ice";
            case 2:
                return "fire";
            case 3:
                return "lightning";
            default:
                return "error";
        }   
    }

    public SPELL_TYPE GetSpellType() 
    {
        return spellType;
    }

    public int GetSpellLevel() 
    {
        return spellLevel;
    }
}
