using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public bool firstMove;
    float distance = 9;
    public GameObject[] pieces;
    public bool perfectPlace;


    // Use this for initialization
    void Start () {
        firstMove = true;
        perfectPlace = true;

    }
	
	// Update is called once per frame
	void Update () {

        //if any piece of the block its in a perfect place 
        perfectPlace = true;
        for(int i=0; i < pieces.Length; i++)
        {
            if (!pieces[i].GetComponent<piece>().nearPiece)
            {
                perfectPlace = false;
                break;
            }
           
        }

        if (perfectPlace)
        {
            Debug.Log("perfect");
        }
    }

    void OnMouseDrag()
    {

        if (firstMove)
        {


            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }
}
