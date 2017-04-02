using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cColor { Black, Red, Unknown };

public class Checker : MonoBehaviour
{

    //Color
    //Whether or not it is flipped
    //Index in the 2D array

	//public animation for each checker
	public Animation animate;

    //move and jump bools that check previous move

    public bool selected;

    #region
    public Vector2 moveUpL;
    public Vector2 moveUpR;
    public Vector2 moveDnL;
    public Vector2 moveDnr;

    public Vector2 jumpUpL;
    public Vector2 jumpUpR;
    public Vector2 jumpDnL;
    public Vector2 jumpDnr;

    public Vector2?[] moveArray = new Vector2?[8];
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

        get { return positionChecker; }

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
		animate = gameObject.GetComponent<Animation>();
        flipped = false;

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
        this.gameObject.GetComponentInChildren<Transform>().position = this.PositionChecker;



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
        checkerManager.GetComponent<CheckerManager>().removeChecker(checkerManager.GetComponent<CheckerManager>().checkBoard[(indexX + ((newX - indexX)/2)), (indexY + ((newY - indexY)/2))]);

        //calls move
        Move(newX, newY, newPosition); //calls jump

    }

    public void Flip()
    {

        //sets flipped to true
        Flipped = true;

    }

	public void AnimateChecker(string animationName)
	{
		//animate.Play (animationName);
	}

    void OnMouseDown()
    {
        Debug.Log("clicked " + gameObject.name);

        checkerManager.GetComponent<CheckerManager>().MoveChecker(gameObject);
    }

}
