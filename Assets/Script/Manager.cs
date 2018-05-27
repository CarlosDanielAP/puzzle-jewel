using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public AudioClip[] soundsFX;
    public static bool play;
    public Text scoreText;
    public int score;
    public int oldscore;
    public int sizeHorizontal;
    public int sizeVertical;
    public Transform[] spaces;
    public static Transform[] myspaces;
    public Transform[] Horizontals;
    public bool completeLineh;
    public bool completeLinev;
    public bool checkall;
    public static bool noblocks;
    public int line;
    public GameObject[] respawns;
    AudioSource audio;
    public int respawnCount;
    public bool perdiste;
    int column;
    // Use this for initialization
    void Awake()
    {
        spaces = new Transform[sizeHorizontal * sizeVertical];
        myspaces = new Transform[sizeHorizontal * sizeVertical];



    }

    void Start() {
        play = false;
        perdiste = false;
        audio = GetComponent<AudioSource>();
        audio.clip = soundsFX[2];
        audio.Play();
        completeLineh = true;
        completeLinev = true;
        checkall = false;
        noblocks = false;

        for (int i = 0; i < spaces.Length; i++)
        {
            //add all the spaces
            spaces[i] = GameObject.Find("space (" + i + ")").transform;
            myspaces[i] = spaces[i];
            
        }
        


    }

    // Update is called once per frame
    void Update() {
       // loose();
       
        

       

        if (play)
        {
            play = false;
            audio.Stop();
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

      
 if (score > oldscore)
        {
            playComplete();
            oldscore += 10;
          for(int i = 0; i < respawns.Length; i++)
            {
                respawns[i].GetComponent<Respawn>().reset();
                
            }

        }

        else
        {
            respawnCount = 0;
            int freespaces = 0;


            for (int i = 0; i < respawns.Length; i++)
            {


                if (respawns[i].GetComponent<Respawn>().myblockname != null)
                {
                    Debug.Log(respawns[i].GetComponent<Respawn>().myblockname);
                    respawnCount++;
                    if (respawns[i].GetComponent<Respawn>().nonboardspace)
                    {
                        freespaces++;
                    }
                    if (freespaces == respawnCount)
                    {
                        Debug.Log("perdistessssssssssssssssssssssssssss" + freespaces + "  " + respawnCount);
                        perdiste = true;
                        Application.LoadLevel("SampleScene");
                    }
                }

            }
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

                // playComplete();

                column = k;
                Debug.Log("completa" + k);

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
                // playComplete();
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

                // playComplete();

                // checkDown();
                score += 10;
                Debug.Log("completa" + line);
                //play animation

                // space.particles(line, spaces);
                //erase that line
                for (int j = line; j < line + sizeHorizontal; j++)
                {
                    foreach (Transform child in spaces[j].transform)
                    {
                        //
                        //spaces[j].GetComponent<space>().m_Animator.SetTrigger("Blue");

                        GameObject.Destroy(child.gameObject);
                        // StartCoroutine(spacetime(j));
                        spaces[j].GetComponent<space>().empty = true;
                        checkDown(false);
                        spaces[j].GetComponent<space>().m_Animator.SetTrigger("Blue");
                        //playComplete();
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
        // AudioSource audio = GetComponent<AudioSource>();
        Debug.Log("audioooooooooooooooooooooooooooooo");
        perdiste = false;
        audio.Stop();
        audio.PlayOneShot(soundsFX[1]);

    }

    void loose(){
       
      

        

    }

   

}

    

