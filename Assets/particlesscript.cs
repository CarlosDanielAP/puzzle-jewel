using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesscript : MonoBehaviour {
    ParticleSystem myparticles;
    public GameObject manager;

	// Use this for initialization
	void Start () {
        myparticles = GetComponent<ParticleSystem>();
        myparticles.Stop();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(manager.GetComponent<Manager>().completeLineh|| manager.GetComponent<Manager>().completeLineh)
        {
            myparticles.Play();
        }
		
	}
}
