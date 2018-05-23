using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour {
    public bool firstMove;
    float distance = 9;
    public GameObject[] pieces;
    public GameObject manager;
    public bool perfectPlace;
    public GameObject spawnPlace;
    public GameObject[] respawns ;
   public static bool perfect;
    private int speed;
    public AudioClip [] put;
    bool complete;
    public Sprite[] sprites;



    // Use this for initialization
    void Start() {
        manager = GameObject.Find("Game Manager");
        respawns = new GameObject[3];
        firstMove = true;
        perfectPlace = true;
        transform.localScale = new Vector2(0.5f, 0.5f);
        complete = false;
        perfect = false;


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
        perfect = false;
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
            perfect = true;
            int myspace;
            int myspaceh;
            for (int i = 0; i < pieces.Length; i++)
            {
              
                if (pieces[i].GetComponent<piece>().nearPiece)
                {

                    myspace = pieces[i].GetComponent<piece>().FindClosestSpacenumbertoPiece();
                    myspaceh = pieces[i].GetComponent<piece>().FindClosestSpacenumbertoPiece();

                    //Debug.Log("perfect" + myspace);

                    //  manager.GetComponent<Manager>().spaces[myspace].GetComponent<space>().empty = false;
                    manager.GetComponent<Manager>().spaces[myspace].GetComponent<space>().near = true;
                    // Debug.Log("myspaaaaaice" + myspace);
                    for (int j = 0; j < 8; j++)
                    {
                        
                        if (myspace > 7)
                        {
                            myspace -= 8;

                        }
                        if(myspace<=7)
                            
                        {
                            int cuenta = 0;
                            int myspace2 = myspace;
                            for (int k = 0; k < 8; k++)
                            {
                                if (manager.GetComponent<Manager>().spaces[myspace2].GetComponent<space>().near)
                                {
                                    cuenta++;
                                    
                                }
                                if (!manager.GetComponent<Manager>().spaces[myspace2].GetComponent<space>().empty)
                                {
                                    cuenta++;

                                }



                               

                                myspace2 += 8;
                                if (cuenta == 8)
                                {
                                    for (int l = 0; l <  8; l++)
                                    {

                                        if (!manager.GetComponent<Manager>().spaces[myspace].GetComponent<space>().empty)
                                        {
                                            Sprite newcolor = pieces[0].transform.GetComponent<SpriteRenderer>().sprite;
                                            manager.GetComponent<Manager>().spaces[myspace].GetComponent<space>().child.GetComponent<SpriteRenderer>().sprite = newcolor;

                                        }
                                        myspace += 8;
                                    }
                                }


                            }
                           


                        }

                    }
                   
                  
                    changeright(myspaceh);



                }
               // else
               // manager.GetComponent<Manager>().spaces[pieces[i].GetComponent<piece>().FindClosestSpacenumbertoPiece()].GetComponent<space>().near = false;
                
            }
                   

        }
    }

    void neighboards() {
        Debug.Log("helloooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
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

    void changeright(int myspace)
    {
        for (int j = 0; j < 8; j++)
        {
            if (myspace % 8 != 0)
            {

                myspace--;
                // firstspace = pieces[i].GetComponent<piece>().spaces[];
            }
            else
            {
                int cuenta = 0;
                for (int k = myspace; k < myspace + 8; k++)
                {


                    if (!manager.GetComponent<Manager>().spaces[k].GetComponent<space>().empty)
                    {
                        cuenta++;


                        //Debug.Log("este no" + k);
                        //Debug.Log(pieces[i].GetComponent<piece>().FindClosestSpacenumbertoPiece() + "popo" + k);

                    }
                    if (manager.GetComponent<Manager>().spaces[k].GetComponent<space>().near)
                    {
                        cuenta++;

                    }
                    if (cuenta == 8)
                    {

                        Debug.Log("KKKKKKKKKKKKKKKKK" + cuenta);
                        for (int l = myspace; l < myspace + 8; l++)
                        {

                            if (!manager.GetComponent<Manager>().spaces[l].GetComponent<space>().empty)
                            {
                                Sprite newcolor = pieces[0].transform.GetComponent<SpriteRenderer>().sprite;
                                manager.GetComponent<Manager>().spaces[l].GetComponent<space>().child.GetComponent<SpriteRenderer>().sprite = newcolor;

                            }
                        }
                    }


                    /*

                        if (k== pieces[i].GetComponent<piece>().FindClosestSpacenumbertoPiece())
                        {
                            Debug.Log("perfect" + myspace);
                        for( int l = myspace; l < myspace + 8; l++)
                            {

                            if (l != pieces[i].GetComponent<piece>().FindClosestSpacenumbertoPiece())
                            {
                                manager.GetComponent<Manager>().spaces[l].GetComponent<space>().child.GetComponent<SpriteRenderer>().sprite =
                                     sprites[0];
                            }
                            }
                        }*/

                }



            }
            // Debug.Log("pppppppppppppppp" + firstspace);
        }
    }
}
