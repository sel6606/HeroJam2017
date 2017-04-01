using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cColor { Black, Red, Unknown };

public class Checker : MonoBehaviour
{

    //Color
    //Whether or not it is flipped
    //Index in the 2D array

    private Vector3 positionChecker;

    public Vector3 PositionChecker
    {

        get { return gameObject.transform.position; }

        set { positionChecker = value; }

    }

    private cColor checkerColor;

    public cColor CheckerColor
    {

        get { return checkerColor; }

        set { checkerColor = value; }

    }

    private bool flipped;

    public bool Flipped
    {

        get { return flipped; }

        set { flipped = value; }

    }

    private int indX;

    public int indexX
    {

        get { return indX; }

        set { indX = value; }

    }

    private int indY;

    public int indexY
    {

        get { return indY; }

        set { indY = value; }

    }

    void Start()
    {

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

    void Move()
    {



    }

    void Jump()
    {



    }
}
