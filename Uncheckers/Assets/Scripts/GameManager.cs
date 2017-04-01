using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject checkerMan;
    private int playerTurn;
    private int piecesP1;
    private int piecesP2;

    //How many pieces are left
    //Win-Lose Conditions


    // Use this for initialization
    void Start ()
    {
        Setup();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Setup()
    {
        playerTurn = 0;
        checkerMan.GetComponent<CheckerManager>().InitArray();
        piecesP1 = checkerMan.GetComponent<CheckerManager>().redLeft;
        piecesP2 = checkerMan.GetComponent<CheckerManager>().blackLeft;
    }

    void UpdateScore()
    {
        //Get values for piecesP1 and piecesP2 from checker manager
        piecesP1 = checkerMan.GetComponent<CheckerManager>().redLeft;
        piecesP2 = checkerMan.GetComponent<CheckerManager>().blackLeft;
    }

    void GameOver()
    {

    }
}
