using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spellGameData : MonoBehaviour
{
    public static spellGameData dataInstance;

    //Will increment after enemy takes a turn
    public int turnCounter = 0;
    public bool diceGamePlaying = false;


    public GameObject endScripting;
    public GameObject endCounting;
    public Text endScript;

    public Text endCount;
    //Holds the spell chosen by the AI, since we should only reference this when the player also chooses it
    public spellScript spellObjectStore; 

    public List<GameObject> allSpellsInPool = new List<GameObject>(); 

    public List<GameObject> spellsForPlayer = new List<GameObject>();

    public List<GameObject> spellsForEnemy = new List<GameObject>();

    private void Awake()
    {
        dataInstance = this;
        endScripting.SetActive(false);
        endCounting.SetActive(false);
        foreach (GameObject spell in GameObject.FindGameObjectsWithTag("Spell Button"))
        {
            allSpellsInPool.Add(spell);
        }
    }

    private void Update()
    {
        if (dataInstance.allSpellsInPool.Count == 0)
        {
            StartCoroutine(spellGameData.dataInstance.ChangeScene());
        }
    }
    //Launches to the defense game after waiting for 3 seconds
    public IEnumerator ChangeScene(){
        float countDown = 3;
        endScripting.SetActive(true);
        endCounting.SetActive(true);

        //Trying to do a countdown timer
        while(countDown > 0){
            Debug.Log("endCount: " + endCount);
            //endCount.text = countDown.ToString();
        //     yield return new WaitForSeconds(1.0f);
            Debug.Log("Countdown: " + countDown.ToString());
            countDown--;
         }
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("DefenseGame");
    }

}
