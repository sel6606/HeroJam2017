using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightClickMoveScript : MonoBehaviour {

    public GameObject checkerMan;

    public int inX;

    public int inY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown()
    {
        Debug.Log("Light clicked");

        CheckerManager checkScri = checkerMan.GetComponent<CheckerManager>();

        if(Mathf.Abs((float)(checkScri.selected.GetComponent<Checker>().indexX - inX)) == 1)
        {
            checkScri.selected.GetComponent<Checker>().Move(inX, inY, gameObject.transform.position);

            checkScri.Deselect(checkScri.selected);
        }
        else
        {
            checkScri.selected.GetComponent<Checker>().Jump(inX, inY, gameObject.transform.position);

            checkScri.PostMove(checkScri.selected);
        }

    }
}
