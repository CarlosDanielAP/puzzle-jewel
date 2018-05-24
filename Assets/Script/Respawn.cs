using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public Transform[] blocks;
    public string myblockname;
    public GameObject manager;
    bool freeSpace;
    int[] mid;
    int[] HrzFive;
    int[] HrzL;
    int[] Square;
    int arraylength;
    // Use this for initialization
    void Start () {
        myblockname = Instantiate(blocks[Random.Range(0,blocks.Length)],new Vector2(transform.position.x,transform.position.y),transform.rotation).name;
        mid = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
        HrzFive = new int[] { 0,1,2,3,4};
        HrzL = new int[] { 0,8,9,10};
        Square = new int[] { 0,1,8,9};
    }
	
	// Update is called once per frame
	void Update () {
        if (Manager.noblocks)
        {
            myblockname = Instantiate(blocks[Random.Range(0, blocks.Length)], new Vector2(transform.position.x, transform.position.y), transform.rotation).name;
            
        }


        if(myblockname== "MidSquare(Clone)"|| myblockname == "MidSquare 1(Clone)")
        {
            arraylength = mid.Length-1;
           

            Check(arraylength,mid);
        }

        if (myblockname == "HrzFive(Clone)" || myblockname == "HrzFive 1(Clone)")
        {
            arraylength = HrzFive.Length - 1;
            Check(arraylength, HrzFive);
        }
        if (myblockname == "HrzL(Clone)" || myblockname == "HrzL 1(Clone)")
        {
            arraylength = HrzL.Length - 1;
            Check(arraylength, HrzL);
        }
        if (myblockname == "Square(Clone)" || myblockname == "Square(Clone)")
        {
            arraylength = Square.Length - 1;
            Check(arraylength, Square);
        }



    }

    void Check(int _arraylenght,int[]_mid)
    {
       
            if (_mid[_arraylenght] <= Manager.myspaces.Length)
            {
                
                for (int i = 0; i < _mid.Length; i++)
                {
                    freeSpace = false;

                    if (Manager.myspaces[_mid[i]].GetComponent<space>().empty)
                    {
                        Debug.Log("caben" + _mid[_arraylenght]);
                        freeSpace = true;
                    }
                    else break;
                    

                }
                if (!freeSpace)
                {
                    for (int j = 0; j < _mid.Length; j++)
                    {
                       _mid[j]++; Debug.Log("no hay no existe" + _mid[j]);
                    }
                   

                }


            }
            else
            {
                Debug.Log("no hay no existe");
            }

           


        
        
           
    }
}
