using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains methods that handle menu behaviors
/// </summary>
public class MenuManager : MonoBehaviour {

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

    }

    /// <summary>
    /// Opens the credits
    /// </summary>
    public void CreditsButton()
    {

    }
}
