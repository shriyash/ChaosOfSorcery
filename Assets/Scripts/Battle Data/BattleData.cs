using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleData : MonoBehaviour
{
    public static BattleData battleDatInstance;

    public int playerHealth;

    public int enemyHealth;

    public List<SpellHolder> playerSpells = new List<SpellHolder>();
    public List<SpellHolder> enemySpells = new List<SpellHolder>();

    void Awake()
    {
        if (battleDatInstance != null && battleDatInstance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            battleDatInstance = this;
            playerHealth = 25;
            enemyHealth = 25;
            DontDestroyOnLoad(this);

            playerSpells.Add(new SpellHolder(SpellHolder.SPELL_TYPE.FIRE, 1));
            playerSpells.Add(new SpellHolder(SpellHolder.SPELL_TYPE.ICE, 1));
            playerSpells.Add(new SpellHolder(SpellHolder.SPELL_TYPE.LIGHTNING, 1));

            enemySpells.Add(new SpellHolder(SpellHolder.SPELL_TYPE.FIRE, 1));
            enemySpells.Add(new SpellHolder(SpellHolder.SPELL_TYPE.ICE, 1));
            enemySpells.Add(new SpellHolder(SpellHolder.SPELL_TYPE.LIGHTNING, 1));
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("SampleScene")) //Destroys once battle is over; need to change "SampleScene" to story scene
        {
            Destroy(this);
        }
    }
}
