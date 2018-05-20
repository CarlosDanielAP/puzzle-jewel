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
    public bool checkall;
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
        checkall = false;

        for (int i = 0; i < spaces.Length; i++)
        {
            //add all the spaces
            spaces[i] = GameObject.Find("space (" + i + ")").transform;
            
            
        }

     

        }

    // Update is called once per frame
    void Update () {



        if (checkall)
        {
            Debug.Log("scanning");
             for (int k = 0; k < spaces.Length; k++)
             {


                 if (spaces[k].transform.childCount <= 0)
                 {

                     spaces[k].GetComponent<space>().empty = true;
                 }
             }
             checkall = false;
        }
        
        else
        {
            for (int i = 0; i < 8; i++)
            {
                checkRight();
            }
            checkall = true;
        }



    }
    void checkDown(bool alone)
    {
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
                
                column = k;
                Debug.Log("completa" + k);
                //erase that line
                for (int j = 0; j < sizeVertical; j++)
                {


                    foreach (Transform child in spaces[column].transform)
                    {
                        GameObject.Destroy(child.gameObject);
                        //make that space usable again
                      if(alone)
                        spaces[column].GetComponent<space>().empty = true;
                    }
                    column += sizeVertical;
                }
               
                break;
            }


        }
        

    }
    void checkRight() {
        Debug.Log("helo");
        for (int i = 0; i < sizeVertical; i++)
        {
            line = i * sizeHorizontal;

            completeLineh = true;
            for (int j = 0; j < sizeHorizontal; j++)
            {

                if (spaces[j + line].GetComponent<space>().empty)
                {
                    completeLineh = false;

                }

            }
            if (completeLineh)
            {
               // checkDown();
                Debug.Log("completa" + line);
                //erase that line
                for (int j = line; j < line + sizeHorizontal; j++)
                {
                    foreach (Transform child in spaces[j].transform)
                    {
                     
                        GameObject.Destroy(child.gameObject);
                        spaces[j].GetComponent<space>().empty = true;
                        checkDown(false);
                        
                      
                    }
                }

              
                break;

               
            }


           

        }
        

        if (!completeLineh)
        {
            checkDown(true);
        }

       


    }

    

}

    

