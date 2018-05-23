using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piece : MonoBehaviour
{

    public GameObject block;
    public GameObject gameManager;
    public Transform[] spaces;
    public bool nearPiece;
    private Transform ClosestSpace;
    private bool stay;
    Sprite myprite;
    int myspace;

    void Start()
    {
        myprite = transform.GetComponent<SpriteRenderer>().sprite;

        gameManager = GameObject.Find("Game Manager");
        nearPiece = false;
        spaces = gameManager.GetComponent<Manager>().spaces;
        stay = false;
    }

    void Update()
    {
        if (!move.perfect)
        {
            transform.GetComponent<SpriteRenderer>().sprite = myprite;
        }

        if (!stay)
        {
            FindClosestSpacetoPiece();


            if (Input.GetMouseButtonUp(0))
            {
                

                //check if all the pieces are in a perfect place
                if (block.GetComponent<move>().perfectPlace)
                {


                    if (nearPiece)
                    {
                        transform.position = new Vector3(FindClosestSpacetoPiece().transform.position.x,
                                                         FindClosestSpacetoPiece().transform.position.y,
                                                         transform.position.z + 0.1f);
                        //ahora el espacio esta ocupado y ya no podemos mover esta pieza
                        FindClosestSpacetoPiece().GetComponent<space>().empty = false;

                        //cant move that block any more
                        block.GetComponent<move>().firstMove = false;
                        Debug.Log("quieta");
                        //unparent of the block parent to the space an destroy block
                        transform.parent = null;
                        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                        transform.SetParent(FindClosestSpacetoPiece(), true);
                        stay = true;

                    }

                }
            }




            /* if (Vector2.Distance(transform.position, spaces[0].transform.position) < 0.5f)
             {
                 Debug.Log("cerca");
                 //si no esta ocupado lo tomamos
                 if (spaces[0].GetComponent<space>().empty)
                 {
                     //si soltamos la pieza ocupa el lugar del espacio
                     if (Input.GetMouseButtonUp(0))
                     {
                         Debug.Log("ocupar");
                         transform.position = new Vector3(spaces[0].transform.position.x, spaces[0].transform.position.y, transform.position.z);
                         //ahora el espacio esta ocupado y ya no podemos mover esta pieza
                         spaces[0].GetComponent<space>().empty = false;


                     }
                 }
             }*/



        }




    }

    public Transform FindClosestSpacetoPiece ()
    {
        float less = 0.5f;
        float dist;
        foreach (Transform space in spaces)
        {
            dist = Vector2.Distance(space.position, transform.position);
            if (dist < less)
            {
                less = dist;
                ClosestSpace = space;
                //check if it is a free space
             if( space.GetComponent<space>().empty )
                nearPiece = true;

            }


            if (less >= 0.5)
            {
                ClosestSpace = null;
                nearPiece = false;
            }
        }
        
        return ClosestSpace;
    }

    public int FindClosestSpacenumbertoPiece()
    {
        float less = 0.1f;
        float dist;
       
        for(int i =0;i<spaces.Length;i++)
        {
            dist = Vector2.Distance(spaces[i].position, transform.position);
            if (dist < less)
            {
                less = dist;
                myspace = i;
                //check if it is a free space
                if (spaces[i].GetComponent<space>().empty)
                    nearPiece = true;

            }


            if (less >= 0.1)
            {
                ClosestSpace = null;
                nearPiece = false;
            }
        }

            return myspace;
   
    }
}