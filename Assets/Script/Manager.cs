using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public int sizeHorizontal;
    public int sizeVertical;
    public Transform []spaces;
    public Transform[] Horizontals;
    public bool completeLineh;
    public bool completeLinev;
    int line;
    int column;
    // Use this for initialization
    void Awake()
    {
        spaces = new Transform[sizeHorizontal * sizeVertical];
       

      
    }

    void Start () {
        completeLineh = true;
        completeLinev = true;

        for (int i = 0; i < spaces.Length; i++)
        {
            //add all the spaces
            spaces[i] = GameObject.Find("space (" + i + ")").transform;
            
            
        }

     

        }

    // Update is called once per frame
    void Update () {
        ///check to the riht
       
            for (int i = 0; i < sizeVertical; i++)
            {
                line = i * sizeHorizontal;

                completeLineh = true;
                for (int j = 0; j < sizeHorizontal; j++)
                {

                if (spaces[j+line].GetComponent<space>().empty)
                    {
                        completeLineh = false;
                    
                    }
               
                }
            if (completeLineh)
            {
                Debug.Log("completa" + line);
                break;
            }


        }
//check down
        for (int k = 0; k < sizeHorizontal; k++)
        {
       
            column = k;
            completeLinev = true;
            for (int j = 0; j < sizeVertical; j++)
            {
            
               
                if (spaces[column].GetComponent<space>().empty)
                {
                    completeLinev = false;

                 break;

                }
                column += 8;
            }
            if (completeLinev)
            {
               Debug.Log("completa" + k);
                break;
            }


        }


    }



}

    

