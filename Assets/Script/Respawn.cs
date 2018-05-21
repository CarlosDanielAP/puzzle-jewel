using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public Transform[] blocks;
	// Use this for initialization
	void Start () {
        Instantiate(blocks[Random.Range(0,blocks.Length)],new Vector2(transform.position.x,transform.position.y),transform.rotation);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Manager.noblocks)
        {
            Instantiate(blocks[Random.Range(0, blocks.Length)], new Vector2(transform.position.x, transform.position.y), transform.rotation);
        }

    }
}
