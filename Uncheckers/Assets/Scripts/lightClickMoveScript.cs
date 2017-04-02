using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightClickMoveScript : MonoBehaviour {

    public GameObject checkerMan;

    public int inX;

    public int inY;

	public bool hasAnimated;

	// Use this for initialization
	void Start () {
		hasAnimated = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown()
    {
        Debug.Log("Light clicked");

        CheckerManager checkScri = checkerMan.GetComponent<CheckerManager>(); 

		if (!checkScri.selected.GetComponent<Checker> ().animate.isPlaying) 
		{
			if(Mathf.Abs((float)(checkScri.selected.GetComponent<Checker>().indexX - inX)) == 1)
			{
				if (hasAnimated == false) 
				{
					checkScri.selected.GetComponent<Checker> ().AnimateChecker ("Slide");
					hasAnimated = true;
				} 
				else 
				{
					checkScri.selected.GetComponent<Checker>().Move(inX, inY, gameObject.transform.position);

					checkScri.Deselect(checkScri.selected);

					hasAnimated = false;
				}
			}
			else
			{
				if (hasAnimated == false) 
				{
					checkScri.selected.GetComponent<Checker> ().AnimateChecker ("Jump");
					hasAnimated = true;
				} 
				else
				{
					checkScri.selected.GetComponent<Checker>().Jump(inX, inY, gameObject.transform.position);

					checkScri.PostMove(checkScri.selected);

					hasAnimated = false;
				}
			}	
		}
    }
}
