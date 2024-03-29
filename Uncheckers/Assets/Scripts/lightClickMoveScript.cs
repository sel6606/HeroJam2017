﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightClickMoveScript : MonoBehaviour {

    public GameObject checkerMan;

    public int inX;

    public int inY;

	public bool hasAnimated;
	public bool hasClicked;

	public CheckerManager checkScri;

	public GameObject flipChecker;
	public GameObject slideChecker;
	public GameObject jumpChecker;

	public GameObject baseChecker;

    private Vector2 distance;
    private Vector3 rot;
    private Vector3 jumprot;
    

	// Use this for initialization
	void Start () {
		hasAnimated = false;
	}
	
	// Update is called once per frame
	void Update () {
        jumprot = Vector3.zero;
		if (checkScri != null && !checkScri.selected.GetComponent<Checker> ().animate.isPlaying && hasClicked == true) 
		{
			if(Mathf.Abs((float)(checkScri.selected.GetComponent<Checker>().indexX - inX)) == 1)
			{
				if (hasAnimated == false) 
				{
                    checkScri.rotLoc = new Vector2(inX, inY);

                    distance = checkScri.posLoc - checkScri.rotLoc;

                    if(distance.x < 0 && distance.y < 0)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 90, 0));
                        rot = new Vector3(0, -90, 0);
                    }
                    if (distance.x < 0 && distance.y > 0)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 180, 0));
                        rot = new Vector3(0, -180, 0);
                    }
                    if (distance.x > 0 && distance.y < 0)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 0, 0));
                        rot = new Vector3(0, 0, 0);

                    }
                    if (distance.x > 0 && distance.y > 0)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 270, 0));
                        rot = new Vector3(0, -270, 0);
                    }

                    checkScri.hasMoved = true;
                    //Instantiate (slideChecker, checkScri.selected.transform.position, checkScri.selected.transform.rotation);
                    checkScri.selected.GetComponent<Checker> ().animate.Play("Slide");
					//checkScri.selected.GetComponent<MeshRenderer>().enabled = false;
					hasAnimated = true;

					Debug.Log ("Start Animation");
					Debug.Log(checkScri.selected.GetComponent<Checker> ().animate.isPlaying);
				} 
				else 
				{
					Debug.Log ("End Animation");

                    checkScri.selected.transform.Rotate(rot);
                    //checkScri.selected.GetComponent<Checker>().animate.Rewind("Slide");
                    checkScri.selected.GetComponent<Checker>().Move(inX, inY, gameObject.transform.position);
					checkScri.Deselect(checkScri.selected);

					checkScri.selected.transform.GetChild(0).transform.position = checkScri.selected.GetComponent<CapsuleCollider> ().bounds.center;

					//checkScri.selected.GetComponent<Checker> ().animate.Rewind();

					//checkScri.selected.GetComponent<MeshRenderer>().enabled = true;
			
					hasAnimated = false;

					hasClicked = false;
				}
			}
			else
			{
				if (hasAnimated == false) 
				{
                    checkScri.hasMoved = true;

                    checkScri.rotLoc = new Vector2(inX, inY);
                    distance = checkScri.posLoc - checkScri.rotLoc;
                    if (distance.x == -2 && distance.y == -2)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 90, 0));
                        jumprot = new Vector3(0, -90, 0);
                    }
                    else if (distance.x == 2 && distance.y == 2)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 270, 0));
                        jumprot = new Vector3(0, -270, 0);
                    }
                    else if (distance.x == 2 && distance.y == -2)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 0, 0));
                        jumprot = new Vector3(0, 0, 0);

                    }
                    else if (distance.x == -2 && distance.y == 2)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 180, 0));
                        jumprot = new Vector3(0, -180, 0);
                    }

                    Debug.Log(distance);
                    checkScri.selected.GetComponent<Checker> ().animate.Play("Jump");
                   
                    hasAnimated = true;
				} 
				else
				{
					checkScri.selected.GetComponent<Checker>().Jump(inX, inY, gameObject.transform.position);

					bool flip = false;

					if (checkScri.HasJumped && checkScri.selected.GetComponent<Checker>().Flipped == false)
					{
						flip = true;
					}

                    checkScri.selected.transform.Rotate(jumprot);
                    checkScri.selected.transform.rotation = Quaternion.Euler(Vector3.zero);
                    

                    checkScri.PostMove(checkScri.selected);
                    
                    checkScri.selected.transform.GetChild(0).transform.position = checkScri.selected.GetComponent<CapsuleCollider> ().bounds.center;

                    distance = checkScri.posLoc - checkScri.rotLoc;
                    if (distance.x == -2 && distance.y == -2)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 90, 0));
                        jumprot = new Vector3(0, -90, 0);
                    }
                    else if (distance.x == 2 && distance.y == 2)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 270, 0));
                        jumprot = new Vector3(0, -270, 0);
                    }
                    else if (distance.x == 2 && distance.y == -2)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 0, 0));
                        jumprot = new Vector3(0, 0, 0);

                    }
                    else if (distance.x == -2 && distance.y == 2)
                    {
                        checkScri.selected.transform.Rotate(new Vector3(0, 180, 0));
                        jumprot = new Vector3(0, -180, 0);
                    }

                    hasAnimated = false;

					hasClicked = false;

					if(flip)
					{
						if (hasAnimated == false) 
						{
							checkScri.selected.GetComponent<Checker> ().animate.Play("Flip");
                            hasAnimated = true;

                            checkScri.changeNow(checkScri.selected);
						
							hasAnimated = false;

							hasClicked = false;

						}
					}
				}
			}
		}

	}
    void OnMouseDown()
    {
        Debug.Log("Light clicked");

        checkScri = checkerMan.GetComponent<CheckerManager>(); 

		if (hasClicked != true) 
		{
			hasClicked = true;
		}

		//if (!checkScri.selected.GetComponent<Checker> ().animate.isPlaying) 
		//{
		//	if(Mathf.Abs((float)(checkScri.selected.GetComponent<Checker>().indexX - inX)) == 1)
		//	{
		//		if (hasAnimated == false) 
		//		{
		//			checkScri.selected.GetComponent<Checker> ().AnimateChecker ("Slide");
		//			hasAnimated = true;
		//		} 
		//		else 
		//		{
		//			checkScri.selected.GetComponent<Checker>().Move(inX, inY, gameObject.transform.position);
		//
		//			checkScri.Deselect(checkScri.selected);
		//
		//			hasAnimated = false;
		//		}
		//	}
		//	else
		//	{
		//		if (hasAnimated == false) 
		//		{
		//			checkScri.selected.GetComponent<Checker> ().AnimateChecker ("Jump");
		//			hasAnimated = true;
		//		} 
		//		else
		//		{
		//			checkScri.selected.GetComponent<Checker>().Jump(inX, inY, gameObject.transform.position);
		//
		//			checkScri.PostMove(checkScri.selected);
		//
		//			hasAnimated = false;
		//		}
		//	}	
		//}
    }
}
