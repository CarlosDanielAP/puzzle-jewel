using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public Texture[] textures;
    public Canvas canvas;
    public Text POINTTEXT;
    public AudioClip[] soundsFX;
    public AudioClip[] pointSounds;
    public static bool play;
    public Text scoreText;
    public Text bestText;
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
       bestText.text= PlayerPrefs.GetInt("Best").ToString();
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

        Debug.Log(oldscore);

       

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


        if (!perdiste)
        {
            if (score > oldscore)
            {

                playSound();

                oldscore = score;
                for (int i = 0; i < respawns.Length; i++)
                {
                    respawns[i].GetComponent<Respawn>().reset();

                }

            }
            else


            {
                losttime();
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
                Particleplay(k, false);
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
                Particleplay(line,true);
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
                        //spaces[j].GetComponent<space>().m_Animator.SetTrigger("Blue");
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
       // audio.Stop();
        audio.PlayOneShot(soundsFX[1]);

    }

    

    void playSound()
    {
        int actualScore;
        actualScore = score-oldscore;

        Animator m_Animator;

        m_Animator = canvas.GetComponent<Animator>();
        // playComplete();

        if (actualScore == 10)
        {

            canvas.GetComponent<AudioSource>().clip = pointSounds[0];

            canvas.GetComponent<AudioSource>().Play();

        }

        if (actualScore == 20)
        {
            //good sound
            canvas.GetComponent<AudioSource>().clip = pointSounds[1];
            POINTTEXT.text = "GOOD";
            canvas.GetComponent<AudioSource>().Play();
            m_Animator.SetTrigger("good");
        }
        if (actualScore == 30)
        {
            //cool sound
            canvas.GetComponent<AudioSource>().clip = pointSounds[2];
            POINTTEXT.text = "COOL";
            canvas.GetComponent<AudioSource>().Play();
            m_Animator.SetTrigger("cool");
        }
        if (actualScore >= 40)
        {
            //perfect sound
            canvas.GetComponent<AudioSource>().clip = pointSounds[3];
            POINTTEXT.text = "Excellent";
            canvas.GetComponent<AudioSource>().Play();
            m_Animator.SetTrigger("perfect");
        }

    }

    IEnumerator gameover()
    {

        yield return new WaitForSeconds(2f);
        Application.LoadLevel("Score");
    }

        void losttime()
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
            }
                
              

        }
        if (freespaces>0&&freespaces == respawnCount)
        {
            Debug.Log("perdistessssssssssssssssssssssssssss" + freespaces + "  " + respawnCount);
            perdiste = true;
            PlayerPrefs.SetInt("Score", score);
            StartCoroutine("gameover");
        }


    }

    void Particleplay(int startline,bool right)
    {
        Debug.Log("audioooooooooooooooooooooooooooooo");
        if (right)
        {
            for (int i = startline; i < startline + 8; i++)
            {
                Debug.Log(move.colorname);
                spaces[i].GetComponent<space>().GetComponent<ParticleSystemRenderer>().material.mainTexture = Resources.Load(move.colorname) as Texture;
                spaces[i].GetComponent<space>().GetComponent<ParticleSystem>().Play();
            }
        }

        if (!right) {
            int k = startline;
            for (int i = startline; i < 8; i++)
            {
                Debug.Log(move.colorname);
                spaces[k].GetComponent<space>().GetComponent<ParticleSystemRenderer>().material.mainTexture = Resources.Load(move.colorname) as Texture;
                spaces[k].GetComponent<space>().GetComponent<ParticleSystem>().Play();
                k += 8;
            }
        }
        
        
      

    }

    public void pauseGame()
    {
        Animator m_Animator;

        m_Animator = canvas.GetComponent<Animator>();


        if (!m_Animator.GetBool("pause")) {
            m_Animator.SetBool("pause", true); 
        }

        else
        {
            m_Animator.SetBool("pause", false);

        }
    }
    public void restart()
    {
        Application.LoadLevel("Game");

    }

}

    

