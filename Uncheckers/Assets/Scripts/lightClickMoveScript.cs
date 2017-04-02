using System.Collections;
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

	// Use this for initialization
	void Start () {
		hasAnimated = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (checkScri != null && !checkScri.selected.GetComponent<Checker> ().animate.isPlaying && hasClicked == true) 
		{
			if(Mathf.Abs((float)(checkScri.selected.GetComponent<Checker>().indexX - inX)) == 1)
			{
				if (hasAnimated == false) 
				{
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
					checkScri.selected.GetComponent<Checker> ().animate.Play("Jump");
					hasAnimated = true;
				} 
				else
				{
					checkScri.selected.GetComponent<Checker>().Jump(inX, inY, gameObject.transform.position);

					bool flip = false;

					if (checkScri.HasJumped)
					{
						flip = true;
					}
			
					checkScri.PostMove(checkScri.selected);

					checkScri.selected.transform.GetChild(0).transform.position = checkScri.selected.GetComponent<CapsuleCollider> ().bounds.center;
			
					hasAnimated = false;

					hasClicked = false;

					if(flip)
					{
						if (hasAnimated == false) 
						{
							checkScri.selected.GetComponent<Checker> ().animate.Play("Flip");
							hasAnimated = true;
						} 
						else
						{
                            Debug.Log("Flipped");

							checkScri.selected.GetComponent<Checker>().Jump(inX, inY, gameObject.transform.position);

                            checkScri.changeNow(checkScri.selected);

							checkScri.selected.transform.GetChild(0).transform.position = checkScri.selected.GetComponent<CapsuleCollider> ().bounds.center;

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
