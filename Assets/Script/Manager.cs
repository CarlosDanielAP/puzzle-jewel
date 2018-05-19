using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public Transform [ ]spaces;
	// Use this for initialization
	void Start () {

        //change the spaces size in the inspector
        for (int i = 0; i < spaces.Length; i++)
        {
           
            spaces[i] = GameObject.Find("space ("+i+")").transform;

        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
