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

    public bool moveUpL;
    public bool moveUpR;
    public bool moveDnL;
    public bool moveDnr;

    public bool jumpUpL;
    public bool jumpUpR;
    public bool jumpDnL;
    public bool jumpDnr;

    public bool prevMoveMove;

    public GameObject checkerManager;

    //returns current Checker Position in 3D space
    private Vector3 positionChecker;

    public Vector3 PositionChecker
    {

        get { return gameObject.transform.position; }

        set { positionChecker = value; }

    }

    //sets enum color of checker
    public cColor checkerColor;

    public cColor CheckerColor
    {

        get { return checkerColor; }

        set { checkerColor = value; }

    }

    //reutnrs true if flipped over, false if unrevieled
    private bool flipped;

    public bool Flipped
    {

        get { return flipped; }

        set { flipped = value; }

    }

    //returns and sets index X in array
    private int indX;

    public int indexX
    {

        get { return indX; }

        set { indX = value; }

    }

    //returns and sets index Y in array
    private int indY;

    public int indexY
    {

        get { return indY; }

        set { indY = value; }

    }

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

    }

    // Update is called once per frame
    void Update()
    {



    }

    void Move(int newX, int newY, Vector3 newPosition)
    {

        this.indexX = newX;

        this.indexY = newY;

        this.PositionChecker = newPosition;

        checkerManager.GetComponent<CheckerManager>().EditArray(this.indexX, this.indexY, newX, newY);

        prevMoveMove = false;

    }

    void Jump(int newX, int newY, Vector3 newPosition)
    {

        Move(newX, newY, newPosition);

        prevMoveMove = false;

    }

    void Flip()
    {

        Flipped = true;

    }

}
