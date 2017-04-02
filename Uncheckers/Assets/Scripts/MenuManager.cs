using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that contains methods that handle menu behaviors
/// </summary>
public class MenuManager : MonoBehaviour {


    public GameObject checkerMan;
    public GameObject gameMan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitButton()
    {
        Debug.Log("Game has quit");
        Application.Quit();
    }

    /// <summary>
    /// Restarts the game
    /// </summary>
    public void RestartButton()
    {
        checkerMan.GetComponent<CheckerManager>().Restart();
        gameMan.GetComponent<GameManager>().gameOver = false;
        gameMan.GetComponent<GameManager>().menu.SetActive(false);
        gameMan.GetComponent<GameManager>().Setup();
    }

    /// <summary>
    /// Opens the credits
    /// </summary>
    public void CreditsButton()
    {

    }

    /// <summary>
    /// Ends the turn of the current player
    /// </summary>
    public void EndTurn(Text turn)
    {
        int temp = gameMan.GetComponent<GameManager>().PlayerTurn;

        if(temp == 1)
        {
            turn.text = "Black Player's Turn";
            gameMan.GetComponent<GameManager>().PlayerTurn = 0;
        }
        else if (temp == 0)
        {
            gameMan.GetComponent<GameManager>().PlayerTurn = 1;
            turn.text = "Red Player's Turn";
        }

        gameMan.GetComponent<GameManager>().FinishTurn = false;
    }
}
