﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerManager : MonoBehaviour {

    //2D array of checker locations
    public GameObject[,] checkBoard = new GameObject[8, 8];

    //The number of red checkers left
    public int redLeft;

    //The number of black checkers left
    public int blackLeft;

    //prefab for the checkers.
    public GameObject checkPre;

    //position for lowes left corner
    private Vector3 basePos;

	// Use this for initialization
	void Start ()
    {
        redLeft = 12;

        blackLeft = 12;

        InitArray();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    bool IsLegal(Checker c)
    {
        return true;
    }

    /// <summary>
    /// Sets up the board, 0 is empty space, 1 is red checker, 2 is black checker
    /// </summary>
    public void InitArray()
    {
        int redNum = 12;

        int blackNum = 12;

        
        //Checks if there are still available red or black peices as it places them, fills the board with checkers
        for(int i = 1; i < 8; i = i+2)
        {

            int check = Random.Range(1, 2);

            GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.x * 1, basePos.y, basePos.z * i), transform.rotation);

            nuCheck.AddComponent<Checker>();

            if (check == 1 && redNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                checkBoard[0, i] = nuCheck;
            }
            else if(check == 2 && blackNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                checkBoard[0, i] = nuCheck;
            }
            else if(redNum == 0 && blackNum == 0)
            {
                return;
            }
            else
            {
                i = i - 2;
            }

            
        }
        for (int i = 0; i < 8; i = i + 2)
        {

            int check = Random.Range(1, 2);

            GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.x * 1, basePos.y, basePos.z * i), transform.rotation);

            nuCheck.AddComponent<Checker>();

            if (check == 1 && redNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                checkBoard[1, i] = nuCheck;
            }
            else if (check == 2 && blackNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                checkBoard[1, i] = nuCheck;
            }
            else if (redNum == 0 && blackNum == 0)
            {
                return;
            }
            else
            {
                i = i - 2;
            }


        }
        for (int i = 1; i < 8; i = i + 2)
        {

            int check = Random.Range(1, 2);

            GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.x * 1, basePos.y, basePos.z * i), transform.rotation);

            nuCheck.AddComponent<Checker>();

            if (check == 1 && redNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                checkBoard[2, i] = nuCheck;
            }
            else if (check == 2 && blackNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                checkBoard[2, i] = nuCheck;
            }
            else if (redNum == 0 && blackNum == 0)
            {
                return;
            }
            else
            {
                i = i - 2;
            }
        }
        for (int i = 1; i < 8; i = i + 2)
        {

            int check = Random.Range(1, 2);

            GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.x * 1, basePos.y, basePos.z * i), transform.rotation);

            nuCheck.AddComponent<Checker>();

            if (check == 1 && redNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                checkBoard[7, i] = nuCheck;
            }
            else if (check == 2 && blackNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                checkBoard[7, i] = nuCheck;
            }
            else if (redNum == 0 && blackNum == 0)
            {
                return;
            }
            else
            {
                i = i - 2;
            }


        }
        for (int i = 0; i < 8; i = i + 2)
        {

            int check = Random.Range(1, 2);

            GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.x * 1, basePos.y, basePos.z * i), transform.rotation);

            nuCheck.AddComponent<Checker>();

            if (check == 1 && redNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                checkBoard[6, i] = nuCheck;
            }
            else if (check == 2 && blackNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                checkBoard[6, i] = nuCheck;
            }
            else if (redNum == 0 && blackNum == 0)
            {
                return;
            }
            else
            {
                i = i - 2;
            }


        }
        for (int i = 1; i < 8; i = i + 2)
        {

            int check = Random.Range(1, 2);

            GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.x * 1, basePos.y, basePos.z * i), transform.rotation);

            nuCheck.AddComponent<Checker>();

            if (check == 1 && redNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                checkBoard[5, i] = nuCheck;
            }
            else if (check == 2 && blackNum > 0)
            {
                nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                checkBoard[5, i] = nuCheck;
            }
            else if (redNum == 0 && blackNum == 0)
            {
                return;
            }
            else
            {
                i = i - 2;
            }


        }
    }

    /// <summary>
    /// Checks where a checker can move
    /// </summary>
    public void IsMoveLegal(Checker check)
    {

    }

    /// <summary>
    /// Checks where a checker can jump
    /// </summary>
    /// <param name="check"></param>
    public void IsJumpLegal(Checker check)
    {

    }


}
