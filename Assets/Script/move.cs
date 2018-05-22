using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour {
    public bool firstMove;
    float distance = 9;
    public GameObject[] pieces;
    public bool perfectPlace;
    public GameObject spawnPlace;
    public GameObject[] respawns ;
    private int speed;
    public AudioClip [] put;



    // Use this for initialization
    void Start() {
     
        respawns = new GameObject[3];
        firstMove = true;
        perfectPlace = true;
        transform.localScale = new Vector2(0.5f, 0.5f);


       //find respawns zone to move the block if it isnt touched
       respawns = GameObject.FindGameObjectsWithTag("Respawn");
        float dist=0.5f;
        float CurDist;

        for (int i = 0; i <respawns.Length; i++)
        {
            CurDist = Vector2.Distance(transform.position, respawns[i].transform.position);
            if (CurDist <= dist)
            {
                Debug.Log("holi");
                spawnPlace = respawns[i].gameObject;
                dist = CurDist;
                Debug.Log(respawns[i]);
            }
        }


    }
    
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, spawnPlace.transform.position, step);
        
        //make bigger and shorter the block
        if (Input.GetMouseButtonUp(0) && !perfectPlace)
        {
            speed = 1000;
            
            transform.localScale = new Vector2(0.5f, 0.5f);
            // gameObject.transform.position = spawnPlace.transform.position;
            
      
        }

        if (Input.GetMouseButtonDown(0))
           
            
        {
            speed = 0;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("Something was clicked!");
                hit.collider.transform.localScale = new Vector2(1f, 1f);
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = put[0];
                audio.Play();
            }

           
        }



            //check if the block have childs if not its destoy


            if (transform.childCount <= 0)
        {
            Manager.play = true;

            Debug.Log("huerfano");
            Destroy(gameObject);
        }



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
