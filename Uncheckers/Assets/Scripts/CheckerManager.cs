using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerManager : MonoBehaviour {

    //2D array of checker locations
    public int[,] checkBoard = new int[8, 8];

    //The number of red checkers left
    public int redLeft;

    //The number of black checkers left
    public int blackLeft;

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

            if(check == 1 && redNum > 0)
            {
                checkBoard[0, i] = check;
            }
            else if(check == 2 && blackNum > 0)
            {
                checkBoard[0,i] = check;
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

            if (check == 1 && redNum > 0)
            {
                checkBoard[1, i] = check;
            }
            else if (check == 2 && blackNum > 0)
            {
                checkBoard[1, i] = check;
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

            if (check == 1 && redNum > 0)
            {
                checkBoard[2, i] = check;
            }
            else if (check == 2 && blackNum > 0)
            {
                checkBoard[2, i] = check;
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

            if (check == 1 && redNum > 0)
            {
                checkBoard[7, i] = check;
            }
            else if (check == 2 && blackNum > 0)
            {
                checkBoard[7, i] = check;
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

            if (check == 1 && redNum > 0)
            {
                checkBoard[6, i] = check;
            }
            else if (check == 2 && blackNum > 0)
            {
                checkBoard[6, i] = check;
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

            if (check == 1 && redNum > 0)
            {
                checkBoard[5, i] = check;
            }
            else if (check == 2 && blackNum > 0)
            {
                checkBoard[5, i] = check;
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



}
