using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public  bool wait;
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
    public int[] Three;
    public int[] Single;
    public int[] UpCorner;
    public int[] VrtFour;
    public int arraylength;
    private int fila;
    int cornerBlock;
    int cornerSave;
    public bool save;
    // Use this for initialization
    void Start()
    {
        wait = false;
        save = true ;
        fila = 0;
        reset();
        myblockname = Instantiate(blocks[Random.Range(0, blocks.Length)], new Vector2(transform.position.x, transform.position.y), transform.rotation).name;
        mid = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
        HrzFive = new int[] { 0, 1, 2, 3, 4 };
        HrzL = new int[] { 0, 8, 9, 10 };
        Square = new int[] { 0, 1, 8, 9 };
        Three = new int[] { 0,1,2};
        Single = new int[] { 0 };
        UpCorner = new int[] { 0 ,1,2,10,18};
        VrtFour= new int[] { 0, 8, 16, 24 };
        cornerBlock = 1;
      
        
    }

    // Update is called once per frame
    void Update()
    {


       
       blocksnames();
        
       

    }


    

    public void blocksnames()
    {


        nonboardspace = false;
         //reset();
            if (Manager.noblocks)
            {
                reset();
                myblockname = Instantiate(blocks[Random.Range(0, blocks.Length)], new Vector2(transform.position.x, transform.position.y), transform.rotation).name;

            }
            if(manager.GetComponent<Manager>().completeLineh|| manager.GetComponent<Manager>().completeLinev)
        {
            reset();
        }
            if (myblockname == null)
            {
                // reset();
            }
            freeSpace = true;
            // nonboardspace = false;

            if (myblockname == "UpCorner(Clone)" || myblockname == "UpCorner 1(Clone)")
            {
                {
                    if (save == true)
                    {
                        fila = 0;
                        cornerBlock = 2;
                        cornerSave = 2;
                        saveBlock = new int[] { 0, 1, 2, 10, 18 };
                        save = false;
                    }

                    arraylength = UpCorner.Length;
                    if (nonboardspace == false)
                    {
                        Check(arraylength, UpCorner);
                    }


                }
            }

            if (myblockname == "tree(Clone)" || myblockname == "tree 1(Clone)")
            {
                {
                    if (save == true)
                    {
                        fila = 0;
                        cornerBlock = 2;
                        cornerSave = 2;
                        saveBlock = new int[] { 0, 1, 2 };
                        save = false;
                    }

                    arraylength = Three.Length;
                    if (nonboardspace == false)
                    {
                        Check(arraylength, Three);
                    }


                }
            }

            if (myblockname == "Single(Clone)" || myblockname == "Single 1(Clone)")
            {
                {
                    if (save == true)
                    {
                        fila = 0;
                        cornerBlock = 0;
                        cornerSave = 0;
                        saveBlock = new int[] { 0 };
                        save = false;
                    }

                    arraylength = Single.Length;
                    if (nonboardspace == false)
                    {
                        Check(arraylength, Single);
                    }


                }
            }



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
            if (myblockname == "Square(Clone)" || myblockname == "Square 1(Clone)")
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
                if (nonboardspace == false)
                {
                    Check(arraylength, Square);
                }


            }
            if (myblockname == "VrtFour(Clone)" || myblockname == "VrtFour 1(Clone)")
            {
                if (save == true)
                {
                    fila = 0;
                    cornerBlock = 0;
                    cornerSave = 0;
                    saveBlock = new int[] { 0, 8, 16, 24 }; ;
                    save = false;
                }

                arraylength = VrtFour.Length;
                if (nonboardspace == false)
                {
                    Check(arraylength, VrtFour);
                }


            }
        
    }
    public void Check(int _arraylenght, int[] _mid)
    {
       
        wait = true;
        if (save == false)
        {

            Debug.Log(cornerBlock + "hora" + cornerSave + "fila" + fila + "mi esquina" + _mid[_mid.Length - 1]);

            if (_mid[_arraylenght - 1] >= Manager.myspaces.Length)
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
                if (_mid[_mid.Length-1] < Manager.myspaces.Length)
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
        wait = false;
    }
    

  public void reset()
    {
       nonboardspace = false;

        //fila = 0;
        //cornerB = 0;
        mid = new int[] { 0, 1, 2, 8, 9, 10, 16, 17, 18 };
        HrzFive = new int[] { 0, 1, 2, 3, 4 };
        HrzL = new int[] { 0, 8, 9, 10 };
        Square = new int[] { 0, 1, 8, 9 };
        Three = new int[] { 0, 1, 2 };
        Single = new int[] { 0 };
        UpCorner = new int[] { 0, 1, 2, 10, 18 };
        VrtFour = new int[] { 0, 8, 16, 24 };
        

       
        save = true;
       // blocksnames();
    }
}

