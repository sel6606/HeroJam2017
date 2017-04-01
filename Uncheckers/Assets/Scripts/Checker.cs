using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cColor { Black, Red, Unknown };

public class Checker : MonoBehaviour
{

    //Color
    //Whether or not it is flipped
    //Index in the 2D array

    //move and jump bools that check previous move

    public bool selected;

    #region
    public bool moveUpL;
    public bool moveUpR;
    public bool moveDnL;
    public bool moveDnr;

    public bool jumpUpL;
    public bool jumpUpR;
    public bool jumpDnL;
    public bool jumpDnr;
    #endregion

    //move bools
    #region
    public bool prevMoveMove;
    public bool moveOver;
    #endregion

    public GameObject checkerManager;

    //returns current Checker Position in 3D space
    #region
    private Vector3 positionChecker;

    public Vector3 PositionChecker
    {

        get { return gameObject.transform.position; }

        set { positionChecker = value; }

    }
    #endregion


    #region
    cColor currentColor;
    
    private cColor checkerColor;


    public cColor CheckerColor
    {

        get { return checkerColor; }

        set { checkerColor = value; }

    }
    #endregion

    //reutnrs true if flipped over, false if unrevieled
    #region
    private bool flipped;

    public bool Flipped
    {

        get { return flipped; }

        set { flipped = value; }

    }
    #endregion

    //returns and sets index X in array
    #region
    private int indX;

    public int indexX
    {

        get { return indX; }

        set { indX = value; }

    }
    #endregion

    //returns and sets index Y in array
    #region
    private int indY;

    public int indexY
    {

        get { return indY; }

        set { indY = value; }

    }
    #endregion

    void Start()
    {

        //checkerManager.GetComponent<CheckerManager>();

    }

    //Creates a checker
    void Create(cColor color, int posX, int posY, bool upFace)
    {

        checkerColor = color;

        indexX = posX;
        indexY = posY;

        Flipped = upFace;

        currentColor = cColor.Unknown;

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void Move(int newX, int newY, Vector3 newPosition)
    {

        //updates checker position in 3d space
        this.PositionChecker = newPosition;

        this.gameObject.transform.position = this.PositionChecker;

        //updates the checker position int the array
        checkerManager.GetComponent<CheckerManager>().EditArray(this.indexX, this.indexY, newX, newY);

        //changes x and y positions of the checker in the array
        this.indexX = newX;

        this.indexY = newY;

    }

    public void MoveOne(int newX, int newY, Vector3 newPosition)
    {

        Move(newX, newY, newPosition); //calls move

        //declares turn over
        moveOver = true;

    }

    public void Jump(int newX, int newY, Vector3 newPosition)
    {

        //calls move
        Move(newX, newY, newPosition); //calls jump

    }

    public void Flip()
    {

        //sets flipped to true
        Flipped = true;

    }

}
