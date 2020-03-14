﻿using UnityEngine;
using UnityEngine.UI;

public class diceGameScript : MonoBehaviour
{
    public  GameObject playerInput;
    public  GameObject enemyInput;
    public  GameObject result;

    public Text playerText;

    // Start is called before the first frame update
    void Start()
    {
        //playerText = playerInput.GetComponentInChildren<Text>();
        hideUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideUI(){
        playerInput.SetActive(false);
        enemyInput.SetActive(false);
        result.SetActive(false);
    }

    public void showUI(){
        playerInput.SetActive(true);
        enemyInput.SetActive(true);
        result.SetActive(true);
    }

    /*
    Dice game script; 
    Will be called once user inputs their value
    Will include
        - taking input from playerInput value
        - comparing to AI value
        - rolling dice/generating random number
        - conditionals for various outcomes
    */
    public void SetUpDiceGame() {
        //Shows input blocks
        showUI();
        //Generates AI's dice value
        AICombatScript.AIDiceGuess();
    }

    public void getPlayerInput(){
        //Need to call another function now that user input is retrieved

    }

}