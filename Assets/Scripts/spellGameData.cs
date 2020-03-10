using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class spellGameData
{
    //Will increment after enemy takes a turn
    public static int turnCounter = 0;
    public static bool diceGamePlaying = false;

    public static List<string> allSpellsInPool = new List<string>(); 

    public static List<string> spellsForPlayer = new List<string>();

    public static List<string> spellsForEnemy = new List<string>();

    //Any data related to spells within the scene will go here

    //List of spells that exist for the player, enemy, and pool -> nonpersistant

    //If diceGamePlaying is true, make spellButton in spellScript inactive, otherwise, do the opposite

}
