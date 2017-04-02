using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckerManager : MonoBehaviour {

    //2D array of checker locations
    public GameObject[,] checkBoard = new GameObject[8, 8];


    //bools if move or jump is possible

    public bool movePos;
    public bool jumpPos;

    //2D array of move indicators
    public GameObject[,] indicBoard = new GameObject[8, 8];

    //The checker chosen to move, can only be changed if hasMoved is false
    public GameObject selected;

    public GameObject lastSelected;

    public bool hasMoved;


    //The number of red checkers left
    public int redLeft;

    //The number of black checkers left
    public int blackLeft;

    //prefab for the checkers.
    public GameObject checkPre;

    //Prefabs for the movement indicators
    public GameObject colChecker;

    //position for lowes left corner
    public GameObject basePos;

	//gameobjects for swapping out objects for animation
	public GameObject checkerS;
	public GameObject checkerJ;
	public GameObject checkerF;

    //float for offset
    float offset;

	// Use this for initialization
	void Start ()
    {
        redLeft = 12;

        blackLeft = 12;

        hasMoved = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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

    /// <summary>
    /// Resets the array to be void
    /// </summary>
    public void Restart()
    {

        for(int i = 0; i < 8; i++)
        {

            for (int j = 0; j < 8; j++)
            {
                Destroy(checkBoard[i, j]);
                checkBoard[i, j] = null;

            }

        }

    }

    /// <summary>
    /// Called whenever an object is clicked
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>

    public void ReturnChecker(PointerEventData data)
    {

        GameObject checkerClick = data.selectedObject;

        GameObject checkerSlected = checkBoard[checkerClick.GetComponent<Checker>().indexX, checkerClick.GetComponent<Checker>().indexY];

        return;

    }

    /// <summary>
    /// Sets up the board, 0 is empty space, 1 is red checker, 2 is black checker
    /// </summary>
    public void InitArray()
    {
        //Float for how far they need to move
		offset = checkPre.transform.GetChild(1).GetComponent<Renderer>().bounds.size.x + (checkPre.transform.GetChild(1).GetComponent<Renderer>().bounds.extents.x / 3);

        int redNum = 12;

        int blackNum = 12;

        redLeft = 12;

        blackLeft = 12;

        bool stagger = false;

        //Checks if there are still available red or black peices as it places them, fills the board with checkers
        for (int j = 0; j < 8; j++)
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
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                        nuCheck.GetComponent<Checker>().indexX = j;

                        nuCheck.GetComponent<Checker>().indexY = i;

                        checkBoard[j, i] = nuCheck;

                        redNum--;
                    }
                    else if (check == 2 && blackNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                        nuCheck.GetComponent<Checker>().indexX = j;

                        nuCheck.GetComponent<Checker>().indexY = i;

                        checkBoard[j, i] = nuCheck;

                        blackNum--;
                    }
                    else if (redNum == 0 && blackNum == 0)
                    {
                        return;
                    }
                    else if (redNum == 0 && blackNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                        nuCheck.GetComponent<Checker>().indexX = j;

                        nuCheck.GetComponent<Checker>().indexY = i;

                        checkBoard[j, i] = nuCheck;

                        blackNum--;
                    }
                    else if (redNum > 0 && blackNum == 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                        nuCheck.GetComponent<Checker>().indexX = j;

                        nuCheck.GetComponent<Checker>().indexY = i;

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
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                        nuCheck.GetComponent<Checker>().indexX = j;

                        nuCheck.GetComponent<Checker>().indexY = i;

                        checkBoard[j, i] = nuCheck;

                        redNum--;
                    }
                    else if (check == 2 && blackNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                        nuCheck.GetComponent<Checker>().indexX = j;

                        nuCheck.GetComponent<Checker>().indexY = i;

                        checkBoard[j, i] = nuCheck;

                        blackNum--;
                    }
                    else if (redNum == 0 && blackNum == 0)
                    {
                        return;
                    }
                    else if (redNum == 0 && blackNum > 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Black;

                        nuCheck.GetComponent<Checker>().indexX = j;

                        nuCheck.GetComponent<Checker>().indexY = i;

                        checkBoard[j, i] = nuCheck;

                        blackNum--;
                    }
                    else if (redNum > 0 && blackNum == 0)
                    {
                        GameObject nuCheck = Instantiate(checkPre, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                        nuCheck.GetComponent<Checker>().checkerManager = gameObject;

                        nuCheck.GetComponent<Checker>().CheckerColor = cColor.Red;

                        nuCheck.GetComponent<Checker>().indexX = j;

                        nuCheck.GetComponent<Checker>().indexY = i;

                        checkBoard[j, i] = nuCheck;

                        redNum--;
                    }
                    stagger = false;
                }
            }
        }
        for (int j = 0; j < 8; j++)
        {


            for (int i = 0; i < 8; i++)
            {
                GameObject clickBox = Instantiate(colChecker, new Vector3(basePos.transform.position.x + offset * j, basePos.transform.position.y, basePos.transform.position.z + offset * i), checkPre.transform.rotation);

                clickBox.GetComponent<lightClickMoveScript>().checkerMan = gameObject;

				clickBox.GetComponent<lightClickMoveScript> ().flipChecker = checkerF;

				clickBox.GetComponent<lightClickMoveScript> ().slideChecker = checkerS;

				clickBox.GetComponent<lightClickMoveScript> ().jumpChecker = checkerJ;

                clickBox.GetComponent<lightClickMoveScript>().inX = j;

                clickBox.GetComponent<lightClickMoveScript>().inY = i;

                indicBoard[j, i] = clickBox;

                clickBox.SetActive(false);
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

        Debug.Log(inX);

        Debug.Log(inY);

        if (inX > 0 && inY < 7 && checkBoard[inX-1,inY+1] == null)
        {
            testCheck.moveArray[0] = new Vector2(inX - 1, inY + 1);
            
        }
        else
        {
            testCheck.moveArray[0] = null;
        }

        if(inX < 7 && inY < 7 && checkBoard[inX + 1, inY + 1] == null)
        {
            testCheck.moveArray[1] = new Vector2(inX + 1, inY + 1);
        }
        else
        {
            testCheck.moveArray[1] = null;
        }
        if (inX < 7 && inY > 0 && checkBoard[inX + 1, inY - 1] == null)
        {
           
            testCheck.moveArray[2] = new Vector2(inX + 1, inY - 1);
        }
        else
        {
            testCheck.moveArray[2] = null;
        }
        if (inX > 0 && inY > 0 && checkBoard[inX - 1, inY - 1] == null)
        {
            testCheck.moveArray[3] = new Vector2(inX - 1, inY - 1);
        }
        else
        {
            testCheck.moveArray[3] = null;

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

        if (inX > 1 && inY < 6 && checkBoard[inX - 1, inY + 1] != null && checkBoard[inX -2, inY + 2] == null)
        {
            testCheck.moveArray[5] = new Vector2(inX - 2, inY + 2);
        }
        else
        {
            testCheck.moveArray[5] = null;
        }
        if (inX < 6 && inY < 6 && checkBoard[inX + 1, inY + 1] != null && checkBoard[inX + 2, inY + 2] == null)
        {
           
            testCheck.moveArray[4] = new Vector2(inX - 2, inY + 2);
        }
        else
        {
            testCheck.moveArray[4] = null;
        }
        if (inX < 6 && inY < 6 && checkBoard[inX + 1, inY + 1] != null && checkBoard[inX + 2, inY + 2] == null)
        {
            testCheck.moveArray[5] = new Vector2(inX + 2, inY + 2);
        }
        else
        {
            testCheck.moveArray[5] = null;
        }
        if (inX > 1 && inY > 1 && checkBoard[inX - 1, inY - 1] != null && checkBoard[inX - 2, inY - 2] == null)
        {
            testCheck.moveArray[6] = new Vector2(inX - 2, inY - 2);

        }
        else
        {
           
            testCheck.moveArray[6] = null;

        }
        if (inX < 6 && inY > 1 && checkBoard[inX + 1, inY - 1] != null && checkBoard[inX + 2, inY - 2] == null)
        {

            testCheck.moveArray[7] = new Vector2(inX + 2, inY - 2);
        }
        else
        {
            testCheck.moveArray[7] = null;
        }
    }

    /// <summary>
    /// Finds what checker was picked, shows where it can move, and allows the user to move it.
    /// </summary>
    /// <param name="data"></param>
    public void MoveChecker(GameObject picked)
    {
        if(lastSelected != null)
        {
            Checker lastInfo = lastSelected.GetComponent<Checker>();

            for (int i = 0; i < 8; i++)
            {
                if (lastInfo.moveArray[i] != null)
                {
                    indicBoard[(int)lastInfo.moveArray[i].GetValueOrDefault().x, (int)lastInfo.moveArray[i].GetValueOrDefault().y].SetActive(false);
                }
            }
        }
        lastSelected = picked;
        if(hasMoved == false)
        {
            selected = picked;
        }
        else
        {
            return;
        }
      
        Checker info = picked.GetComponent<Checker>();

        IsMoveLegal(picked);

        IsJumpLegal(picked);

        for(int i = 0; i < 8; i++)
        {
            if(info.moveArray[i] != null)
            {
                indicBoard[(int)info.moveArray[i].GetValueOrDefault().x, (int)info.moveArray[i].GetValueOrDefault().y].SetActive(true);
            }
        }
    }

    /// <summary>
    /// Shows whethe a checker can jump after jumping
    /// </summary>
    /// <param name="picked"></param>
    public void PostMove(GameObject picked)
    {
        Checker info = picked.GetComponent<Checker>();

        for (int i = 0; i < 8; i++)
        {
            if (info.moveArray[i] != null)
            {
                indicBoard[(int)info.moveArray[i].GetValueOrDefault().x, (int)info.moveArray[i].GetValueOrDefault().y].SetActive(false);
            }
        }
        IsJumpLegal(picked);
        for (int i = 4; i < 8; i++)
        {
            if (info.moveArray[i] != null)
            {
                indicBoard[(int)info.moveArray[i].GetValueOrDefault().x, (int)info.moveArray[i].GetValueOrDefault().y].SetActive(true);
            }
        }

    }

    public void Deselect(GameObject picked)
    {
        Checker info = picked.GetComponent<Checker>();

        for (int i = 0; i < 8; i++)
        {
            if (info.moveArray[i] != null)
            {
                indicBoard[(int)info.moveArray[i].GetValueOrDefault().x, (int)info.moveArray[i].GetValueOrDefault().y].SetActive(false);
            }

        }
    }


}
