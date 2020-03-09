using UnityEngine;

public class diceGameScript : MonoBehaviour
{
    public GameObject playerInput;
    public GameObject enemyInput;
    public GameObject result;
    // Start is called before the first frame update
    void Start()
    {
        hideUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hideUI(){
        playerInput.SetActive(false);
        enemyInput.SetActive(false);
        result.SetActive(false);
    }

    void showUI(){
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
    public void diceGame() {

    }
}
