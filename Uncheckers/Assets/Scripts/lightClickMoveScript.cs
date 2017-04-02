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

        checkScri.selected.GetComponent<Checker>().Move(inX, inY, gameObject.transform.position);

        checkScri.PostMove(checkScri.selected);
    }
}
