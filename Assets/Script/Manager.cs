using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public AudioClip[] soundsFX;
    public static bool play;
    public Text scoreText;
    public  int score;
    public int sizeHorizontal;
    public int sizeVertical;
    public Transform []spaces;
    public Transform[] Horizontals;
    public bool completeLineh;
    public bool completeLinev;
    public bool checkall;
    public static bool noblocks;
   public  int line;
    int column;
    // Use this for initialization
    void Awake()
    {
        spaces = new Transform[sizeHorizontal * sizeVertical];
       

      
    }

    void Start () {
        play = false;


        completeLineh = true;
        completeLinev = true;
        checkall = false;
        noblocks = false;

        for (int i = 0; i < spaces.Length; i++)
        {
            //add all the spaces
            spaces[i] = GameObject.Find("space (" + i + ")").transform;
            
            
        }

     

        }

    // Update is called once per frame
    void Update () {
        if (play)
        {
            play = false;
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = soundsFX[0];
            audio.Play();
        }

        scoreText.text = score.ToString();

        //check if there are no block to play
        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            noblocks = true;
        }
        if (GameObject.FindGameObjectsWithTag("Block").Length > 0)
        {
            noblocks = false;
        }


            if (checkall)
        {
            Debug.Log("scanning");
             for (int k = 0; k < spaces.Length; k++)
             {


                 if (spaces[k].transform.childCount <= 0)
                 {
                    //StartCoroutine(spacetime(k));
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
                playComplete();
                score += 10;
                //erase that line
               // space.particlesvertical(column, spaces);

                for (int j = 0; j < sizeVertical; j++)
                {


                    foreach (Transform child in spaces[column].transform)
                    {
                        GameObject.Destroy(child.gameObject);
                        //make that space usable again
                        if (alone)
                        {
                            // StartCoroutine(spacetime (column));
                           
                            spaces[column].GetComponent<space>().empty = true;
                        }
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
                score += 10;
                Debug.Log("completa" + line);
                playComplete();
                // space.particles(line, spaces);
                //erase that line
                for (int j = line; j < line + sizeHorizontal; j++)
                {
                    foreach (Transform child in spaces[j].transform)
                    {
                     
                        GameObject.Destroy(child.gameObject);
                       // StartCoroutine(spacetime(j));
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

    void playComplete()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = soundsFX[1];
        audio.Play();
    }

   

}

    

