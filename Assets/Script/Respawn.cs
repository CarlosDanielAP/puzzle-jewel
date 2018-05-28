using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform[] blocks;
    public string myblockname;
    public GameObject manager;
    public bool freeSpace;
    public bool nonboardspace;
   public int[] saveBlock;
    public int []saveCorner;
    public int[] mid;
    public int[] HrzFive;
    public int[] HrzL;
    public int[] Square;
    public int[] cornermid;
    public int[] cornerHzFive;
    public int[] cornerHrzL;
    public int[] cornerSquare;
    public int arraylength;
    private int fila;
    int cornerBlock;
    int cornerSave;
    public bool save;
    // Use this for initialization
    void Start()
    {
        save = true ;
        fila = 0;
        reset();
        myblockname = Instantiate(blocks[Random.Range(0, blocks.Length)], new Vector2(transform.position.x, transform.position.y), transform.rotation).name;
        mid = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
        HrzFive = new int[] { 0, 1, 2, 3, 4 };
        HrzL = new int[] { 0, 8, 9, 10 };
        Square = new int[] { 0, 1, 8, 9 };
        cornermid = new int[] { 2,0 };
        cornerHzFive = new int[] { 4,0 };
        cornerHrzL = new int[] { 2,0 };
        cornerSquare = new int[] {1,0};
        cornerBlock = 1;
      
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Manager.noblocks)
        {
             reset();
            myblockname = Instantiate(blocks[Random.Range(0, blocks.Length)], new Vector2(transform.position.x, transform.position.y), transform.rotation).name;

        }
        if (myblockname == null)
        {
          // reset();
        }
        freeSpace = true;
       // nonboardspace = false;

       


       if (myblockname == "MidSquare(Clone)" || myblockname == "MidSquare 1(Clone)")
        {
            {
                if (save == true)
                {
                    fila = 0;
                    cornerBlock = 2;
                    cornerSave = 2;
                    saveBlock = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
                    save = false;
                }

                arraylength = mid.Length;
                if (nonboardspace == false)
                {
                    Check(arraylength, mid);
                }


            }
        }

        if (myblockname == "HrzFive(Clone)" || myblockname == "HrzFive 1(Clone)")
        {
            {
                if (save == true)
                {
                    fila = 0;
                    cornerBlock = 4;
                    cornerSave = 4;
                    saveBlock = new int[] { 0, 1, 2, 3, 4 };
                    save = false;
                }

                arraylength = HrzFive.Length;
                if (nonboardspace == false)
                {
                    Check(arraylength, HrzFive);
                }


            }
        }
        if (myblockname == "HrzL(Clone)" || myblockname == "HrzL 1(Clone)")
        {
            {
                if (save == true)
                {
                    fila = 0;
                    cornerBlock = 2;
                    cornerSave = 2;
                    saveBlock = new int[] { 0, 8, 9, 10 };
                    save = false;
                }

                arraylength = HrzL.Length;
                if (nonboardspace == false)
                {
                    Check(arraylength, HrzL);
                }


            }
        }
        if (myblockname == "Square(Clone)" || myblockname == "Square(Clone)")
        {
            if (save == true)
            {
                fila = 0;
                cornerBlock = 1;
                cornerSave = 1;
                saveBlock = new int[] { 0, 1, 8, 9 }; ;
                save = false;
            }
 
            arraylength = Square.Length;
            if (nonboardspace ==false)
            {
                Check(arraylength, Square);
            }
           
           
        }



    }

    public void Check(int _arraylenght, int[] _mid)
    {
        if (save == false)
        {

            Debug.Log(cornerBlock + "hora" + cornerSave + "fila" + fila + "mi esquina" + _mid[_mid.Length - 1]);

            if (_mid[_arraylenght - 1] > Manager.myspaces.Length)
            {
                Debug.Log("perdiste");
                nonboardspace = true;

            }


            else
            {
                if (cornerBlock > (fila + 7) )
                {
                    // reset();
                    fila += 8;
                    cornerBlock = cornerSave + fila;
                    for (int i = 0; i < _mid.Length; i++)
                    {
                        _mid[i] = saveBlock[i] + fila;
                        Debug.Log(_mid[i]);

                    }


                }
                if (_mid[_mid.Length-1] <= Manager.myspaces.Length)
                {

                    for (int n = cornerBlock; n < fila + 8; n++)
                    {


                        for (int i = 0; i < _mid.Length; i++)
                        {
                            freeSpace = false;

                            if (Manager.myspaces[_mid[i]].GetComponent<space>().empty)
                            {

                                // Debug.Log("caben" + _mid[i]);
                                freeSpace = true;
                            }

                            else
                            {

                                break;
                            }


                        }
                        if (!freeSpace)
                        {
                            if (_mid[_arraylenght - 1] < Manager.myspaces.Length)
                            {
                                cornerBlock++;
                                for (int j = 0; j < _mid.Length; j++)
                                {
                                    _mid[j]++;

                                    Debug.Log("lleno hasta" + cornerBlock);
                                }
                                Check(_arraylenght, _mid);
                                break;
                            }
                            else break;
                        }

                        if (freeSpace)
                        {
                            break;
                        }
                    }
                }


            }
        }
    }
    

            public void reset()
    {

       
        //fila = 0;
        //cornerB = 0;
        mid = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
        HrzFive = new int[] { 0, 1, 2, 3, 4 };
        HrzL = new int[] { 0, 8, 9, 10 };
        Square = new int[] { 0, 1, 8, 9 };
        cornermid = new int[] { 2,0 };
        cornerHzFive = new int[] { 4,0 };
        cornerHrzL = new int[] { 2,0 };
        cornerSquare = new int[] { 1,0 };
        nonboardspace = false;
        save = true;
    }
}

