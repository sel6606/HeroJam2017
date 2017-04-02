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

	// Use this for initialization
	void Start () {
		hasAnimated = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (checkScri != null && !checkScri.selected.GetComponent<Checker>().animate.isPlaying && hasClicked == true) 
		{
			if(Mathf.Abs((float)(checkScri.selected.GetComponent<Checker>().indexX - inX)) == 1)
			{
				if (hasAnimated == false) 
				{
                    checkScri.selected.GetComponent<Checker>().animate.Play("Slide");

                    hasAnimated = true;
				} 
				else 
				{
					checkScri.selected.GetComponent<Checker>().MoveOne(inX, inY, gameObject.transform.position);
			
					checkScri.Deselect(checkScri.selected);
			
					hasAnimated = false;

					hasClicked = false;
				}
			}
			else
			{
				if (hasAnimated == false) 
				{
                    checkScri.selected.GetComponent<Checker>().animate.Play("Jump");
					hasAnimated = true;
				} 
				else
				{
					checkScri.selected.GetComponent<Checker>().Jump(inX, inY, gameObject.transform.position);
			
					checkScri.PostMove(checkScri.selected);
			
					hasAnimated = false;

					hasClicked = false;
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
