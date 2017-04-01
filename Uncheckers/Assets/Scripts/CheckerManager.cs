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
    public GameObject basePos;

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

    ///<summary>
    /// Accesses and edits the array for a checker objects
    ///</summary>
    public void EditArray(int oldIndexX, int oldIndexY, int newIndexX, int newIndexY)
    {

        //stores checker
        GameObject tempHold = checkBoard[oldIndexX, oldIndexY];

        //moves checker to new position
        checkBoard[newIndexX, newIndexY] = tempHold;

        //removes old checker
        checkBoard[oldIndexX, oldIndexY] = null;

    }

    ///<summary>
    /// Removes a checker from the array
    ///</summary>
    public void removeChecker(GameObject ob)
    {
        Checker check = ob.GetComponent<Checker>();

        checkBoard[check.indexX, check.indexY] = null;

        if(check.CheckerColor == cColor.Black)
        {
            blackLeft--;
        }
        if(check.CheckerColor == cColor.Red)
        {
            redLeft--;
        }

        Destroy(ob);
        

    }

    public void Restart()
    {

        for(int i = 0; i < 7; i++)
        {

            for (int j = 0; j < 7; j++)
            {

                checkBoard[i, j] = null;

            }

        }

    }

    /*public Checker ReturnChecker()
    {

        Checker clicked;

        foreach(Checker check in checkBoard)
        {

            if (Input.GetButtonDown("Fire1"))
            {



            }

        }       

        return clicked;

    }*/

    /// <summary>
    /// Sets up the board, 0 is empty space, 1 is red checker, 2 is black checker
    /// </summary>
    public void InitArray()
    {
        int redNum = 12;

        int blackNum = 12;

        redLeft = 12;

        blackLeft = 12;

        bool stagger = false;

        //Checks if there are still available red or black peices as it places them, fills the board with checkers
        for(int j = 0; j < 8; j++)
        {
            if (j == 3 || j == 4)
            {
                continue;
            }
            else if (!stagger)
            {


                for (int i = 1; i < 8; i = i + 2)
                {

                    int check = Random.Range(1, 3);

                    if (check == 1 && redNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + checkPre.transform.localScale.x * j, basePos.transform.position.y, basePos.transform.position.z + checkPre.transform.localScale.z * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                        checkBoard[j, i] = nuCheck;

                        redNum--;
                    }
                    else if (check == 2 && blackNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + checkPre.transform.localScale.x * j, basePos.transform.position.y, basePos.transform.position.z + checkPre.transform.localScale.z * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                        checkBoard[j, i] = nuCheck;

                        blackNum--;
                    }
                    else if (redNum == 0 && blackNum == 0)
                    {
                        return;
                    }
                    else if (redNum == 0 && blackNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + checkPre.transform.localScale.x * j, basePos.transform.position.y, basePos.transform.position.z + checkPre.transform.localScale.z * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                        checkBoard[j, i] = nuCheck;

                        blackNum--;
                    }
                    else if (redNum > 0 && blackNum == 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + checkPre.transform.localScale.x * j, basePos.transform.position.y, basePos.transform.position.z + checkPre.transform.localScale.z * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                        checkBoard[j, i] = nuCheck;

                        redNum--;
                    }
                    stagger = true;
                }
            }
            else if (stagger)
            {
                for (int i = 0; i < 8; i = i + 2)
                {

                    int check = Random.Range(1, 3);

                    if (check == 1 && redNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + checkPre.transform.localScale.x * j, basePos.transform.position.y, basePos.transform.position.z + checkPre.transform.localScale.z * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                        checkBoard[j, i] = nuCheck;

                        redNum--;
                    }
                    else if (check == 2 && blackNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + checkPre.transform.localScale.x * j, basePos.transform.position.y, basePos.transform.position.z + checkPre.transform.localScale.z * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                        checkBoard[j, i] = nuCheck;

                        blackNum--;
                    }
                    else if (redNum == 0 && blackNum == 0)
                    {
                        return;
                    }
                    else if (redNum == 0 && blackNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + checkPre.transform.localScale.x * j, basePos.transform.position.y, basePos.transform.position.z + checkPre.transform.localScale.z * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                        checkBoard[j, i] = nuCheck;

                        blackNum--;
                    }
                    else if (redNum > 0 && blackNum == 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + checkPre.transform.localScale.x * j, basePos.transform.position.y, basePos.transform.position.z + checkPre.transform.localScale.z * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                        checkBoard[j, i] = nuCheck;

                        redNum--;
                    }
                    stagger = false;
                }
            }
        }
       
    }

    /// <summary>
    /// Checks where a checker can move
    /// </summary>
    public void IsMoveLegal(GameObject check)
    {
        Checker testCheck = check.GetComponent<Checker>();

        int inX = testCheck.indexX;

        int inY = testCheck.indexY;

        if(inX > 1 && inY < 7 && checkBoard[inX-1,inY+1] == null)
        {
            testCheck.moveUpL = true;
        }
        if (inX < 7 && inY < 7 && checkBoard[inX + 1, inY + 1] == null)
        {
            testCheck.moveUpR = true;
        }
        if (inX < 7 && inY > 1 && checkBoard[inX + 1, inY - 1] == null)
        {
            testCheck.moveDnr = true;
        }
        if (inX > 1 && inY > 1 && checkBoard[inX - 1, inY - 1] == null)
        {
            testCheck.moveDnL = true;
        }
    }

    /// <summary>
    /// Checks where a checker can jump
    /// </summary>
    /// <param name="check"></param>
    public void IsJumpLegal(GameObject check)
    {
        Checker testCheck = check.GetComponent<Checker>();

        int inX = testCheck.indexX;

        int inY = testCheck.indexY;

        if (inX > 2 && inY < 6 && checkBoard[inX - 1, inY + 1] != null && checkBoard[inX -2, inY + 2] == null)
        {
            testCheck.jumpUpL = true;
        }
        if (inX < 6 && inY < 6 && checkBoard[inX + 1, inY + 1] != null && checkBoard[inX + 2, inY + 2] == null)
        {
            testCheck.jumpUpR = true;
        }
        if (inX > 2 && inY > 2 && checkBoard[inX - 1, inY - 1] != null && checkBoard[inX - 2, inY - 2] == null)
        {
            testCheck.jumpDnL = true;
        }
        if (inX < 6 && inY > 2 && checkBoard[inX + 1, inY - 1] != null && checkBoard[inX + 2, inY - 2] == null)
        {
            testCheck.jumpDnr = true;
        }
    }


}
