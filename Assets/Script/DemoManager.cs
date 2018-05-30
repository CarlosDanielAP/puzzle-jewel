using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoManager : MonoBehaviour {

    public GameObject space;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       if(space.transform.childCount >0 )
        {
            StartCoroutine(losttime());
        }
		
	}


    IEnumerator losttime()
    {

        yield return new WaitForSeconds(2f);
        Application.LoadLevel("Game");


    }

    }
