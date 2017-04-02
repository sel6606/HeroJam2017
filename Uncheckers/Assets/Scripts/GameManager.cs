using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script that manages the game states and information
/// </summary>
public class GameManager : MonoBehaviour {

    #region Public Variables
    public GameObject checkerMan;
    public GameObject menu;
    public GameObject menuMan;
    public Text blackText;
    public Text redText;
    public Text turn;
    public Text gameOverText;
    public bool gameOver;
    #endregion

    #region Class Variables
    private int playerTurn;
    private int piecesP1;
    private int piecesP2;
    private bool finishTurn;
    #endregion

    public int PlayerTurn
    {
        get { return playerTurn; }
        set { playerTurn = value; }
    }

    public bool FinishTurn
    {
        get { return finishTurn; }
        set { finishTurn = value; }
    }


    // Use this for initialization
    void Start ()
    {
        finishTurn = false;
        gameOver = false;
        menu.SetActive(false);
        Setup();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //If the game is over call GameOver, otherwise update the score
        if (gameOver)
        {
            if (piecesP1 == 0)
            {
                GameOver(0);
            }
            else if (piecesP2 == 0)
            {
                GameOver(1);
            }
        }
        else
        {
            UpdateScore();
        }

        if(finishTurn)
        {
            menuMan.GetComponent<MenuManager>().EndTurn(turn);
        }
	}

    /// <summary>
    /// Tells the checker manager to initialize the array and sets up the initial values of the pieces remaining
    /// </summary>
    public void Setup()
    {
        playerTurn = 0;
        checkerMan.GetComponent<CheckerManager>().InitArray();
        piecesP1 = checkerMan.GetComponent<CheckerManager>().redLeft;
        piecesP2 = checkerMan.GetComponent<CheckerManager>().blackLeft;
    }

    /// <summary>
    /// Retrieves the number of pieces remaining and updates the UI to match
    /// </summary>
    void UpdateScore()
    {
        //Get values for piecesP1 and piecesP2 from checker manager
        piecesP1 = checkerMan.GetComponent<CheckerManager>().redLeft;
        piecesP2 = checkerMan.GetComponent<CheckerManager>().blackLeft;

        //Update the UI text
        redText.text = "Red Pieces Remaining: " + piecesP1;
        blackText.text = "Black Pieces Remaining: " + piecesP2;

        //If a player runs out of pieces, set gameover to true
        if(piecesP1 == 0 || piecesP2 == 0)
        {
            gameOver = true;
        }
    }

    /// <summary>
    /// Checks to see if the player is still capable of moving a piece
    /// if not the turn ends
    /// </summary>
    void EndTurn()
    {

        //if((checkerMan.GetComponent<CheckerManager>().movePos == false && checkerMan.GetComponent<CheckerManager>().jumpPos == false) || )

    }

    /// <summary>
    /// Ends the game and declares a winner.
    /// </summary>
    /// <param name="winner">The winner of the game, 0 for black, 1 for red</param>
    void GameOver(int winner)
    {
        menu.SetActive(true);
        if(winner == 0)
        {
            gameOverText.text = "Game Over! Black wins!";
        }
        else if (winner == 1)
        {
            gameOverText.text = "Game Over! Red wins!";
        }
    }
}
