using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public int sizeHorizontal;
    public int sizeVertical;
    public Transform []spaces;
    public Transform[] Horizontals;
    public bool completeLine;
    int line;
    int column;
    // Use this for initialization
    void Awake()
    {
        spaces = new Transform[sizeHorizontal * sizeVertical];
       

      
    }

    void Start () {
        completeLine = true;

        for (int i = 0; i < spaces.Length; i++)
        {
            //add all the spaces
            spaces[i] = GameObject.Find("space (" + i + ")").transform;
            
            
        }

        





        }

    // Update is called once per frame
    void Update () {
        
        for (int i = 0; i < sizeHorizontal; i++)
        {
            column = i;


            for (int j = 0; j < sizeVertical; j++)
            {
                Debug.Log(column);
                column+=  sizeVertical;
               


            }
            
        }
        


        for (int j = 0; j <= spaces.Length; j++)
        {
            
            completeLine = true;
            
             
            //completeLine = true;

            Debug.Log(column);

            if (spaces[column].GetComponent<space>().empty)
            {
                completeLine = false;



            }
            column += 8;

            if (completeLine)
            {
                Debug.Log("completa" + line);

            }









            //check horizontal lines
            /*  if (j >= 8)
              {
                  if (j % 8 == 0)
                  {
                      line = j;


                      for (int i = line - 8; i < line; i++)
                      {

                          if (spaces[i].GetComponent<space>().empty)
                          {
                              completeLine = false;
                              break;
                          }


                      }
                      if (completeLine)
                      {
                          Debug.Log("completa" + line);
                          break;
                      }

                  }
              }

              */




        }



    }

    
}
