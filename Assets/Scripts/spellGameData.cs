using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellGameData : MonoBehaviour
{
    public static spellGameData dataInstance;

    //Will increment after enemy takes a turn
    public int turnCounter = 0;
    public bool diceGamePlaying = false;

    //Holds the spell chosen by the AI, since we should only reference this when the player also chooses it
    public spellScript spellObjectStore; 

    public List<GameObject> allSpellsInPool = new List<GameObject>(); 

    public List<GameObject> spellsForPlayer = new List<GameObject>();

    public List<GameObject> spellsForEnemy = new List<GameObject>();

    private void Awake()
    {
        dataInstance = this;
        foreach (GameObject spell in GameObject.FindGameObjectsWithTag("Spell Button"))
        {
            allSpellsInPool.Add(spell);
        }
    }

    //Any data related to spells within the scene will go here

    //List of spells that exist for the player, enemy, and pool -> nonpersistant

    //If diceGamePlaying is true, make spellButton in spellScript inactive, otherwise, do the opposite

}
