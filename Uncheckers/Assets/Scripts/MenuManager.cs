﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        checkerMan.GetComponent<CheckerManager>().InitArray();
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
}