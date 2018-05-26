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
    private int[] saveBlock;
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
        if (myblockname == null)
        {
          // reset();
        }
        freeSpace = true;
        nonboardspace = false;

        if (Manager.noblocks)
        {
           // reset();
            myblockname = Instantiate(blocks[Random.Range(0, blocks.Length)], new Vector2(transform.position.x, transform.position.y), transform.rotation).name;

        }


      /*  if (myblockname == "MidSquare(Clone)" || myblockname == "MidSquare 1(Clone)")
        {
            if (save == true)
            {
                saveBlock = mid;
                saveCorner = cornermid[0];
                save = false;
            }

            arraylength = mid.Length;

        
            Check(arraylength, mid, cornermid);
        }

        if (myblockname == "HrzFive(Clone)" || myblockname == "HrzFive 1(Clone)")
        {
            if (save == true)
            {
                saveBlock = HrzFive;
                saveCorner = cornerHzFive[0];
                save = false;
            }


            arraylength = HrzFive.Length;
            Check(arraylength, HrzFive, cornerHzFive);
        }
        if (myblockname == "HrzL(Clone)" || myblockname == "HrzL 1(Clone)")
        {
            if (save == true)
            {
                saveCorner = cornerHrzL[0];
                saveBlock =HrzL;
                save = false;
            }
            arraylength = HrzL.Length;
            Check(arraylength, HrzL, cornerHrzL);
        }*/
        if (myblockname == "Square(Clone)" || myblockname == "Square(Clone)")
        {
            if (save == true)
            {
                fila = 0;
                cornerBlock = 1;
                cornerSave = cornerBlock;
                saveBlock = new int[] { 0, 1, 8, 9 }; ;
                save = false;
            }
            //Square = new int[] { 0, 1, 8, 9 };

        // Debug.Log(cornerSquare[0]+"fila"+cornerSquare[1]);
          //  Debug.Log(Square[1]);
           // Debug.Log(saveCorner);

            arraylength = Square.Length;
            Check(arraylength, Square);
           
           
        }



    }

    void Check(int _arraylenght, int[] _mid)
    {

      

        
       
            if (_mid[_arraylenght-1] <= Manager.myspaces.Length)
        {

            if (cornerBlock> ( fila + 8)-cornerSave)
            {
               // reset();
                fila += 8;
                cornerBlock = cornerSave+fila;
                for (int i = 0; i < _mid.Length; i++)
                {
                    _mid[i] = saveBlock[i] + fila;
                }
              

            }

            for (int n = cornerBlock; n < fila + 8; n++)
            {

                Debug.Log(cornerBlock + "hora" + cornerSave + "fila" + fila+"mi esquina"+_mid[1]+"cuadrito guardado"+saveBlock[1]);

                for (int i = 0; i < _mid.Length; i++)
                {
                    freeSpace = false;

                    if (Manager.myspaces[_mid[i]].GetComponent<space>().empty)
                    {

                        // Debug.Log("caben" + _mid[i]);
                        freeSpace = true;
                    }

                    else {

                        break;
                    }


                }
                if (!freeSpace)
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

                if (freeSpace)
                {
                    break;
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
       // save = true;
    }
}

