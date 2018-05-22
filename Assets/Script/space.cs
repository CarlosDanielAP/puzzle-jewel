using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space : MonoBehaviour {
    public bool empty;
    public static bool emit;
    ParticleSystem myparticles;
    public GameObject manager;
    static public space instance;
    bool pause;
    int lines;

    void Awake()
    {
       instance = this;
    }

    // Use this for initialization
    void Start () {
        
        empty = true;
    

    }
	
	// Update is called once per frame
	void Update () {

      /*  if (manager.GetComponent<Manager>().completeLineh)
        {
               

            int line = manager.GetComponent<Manager>().line;
            //erase that line
            for (int j = line; j < line + 8; j++)
            {
                foreach (Transform child in manager.GetComponent<Manager>().spaces[j].transform)
                {


                    // StartCoroutine(spacetime(j));
                    if (!empty)
                    {
                        myparticles.Play();
                    }


                }
            }



            
        }*/

        /*if (!myparticles.IsAlive())
        {
            myparticles.Stop();
        }*/
   
	}

   /* public static void particles(int line,Transform[] spaces)
    {
        ParticleSystem myparticles;
     
        for (int j = line; j < line + 8; j++)
            {
            Debug.Log("lineaaaaaaaaaaaaaaaaaaaaa" + j);
            myparticles =spaces[j].GetComponent<ParticleSystem>();
            instance.StartCoroutine(instance.spacetime());
            if (!instance.pause)
            {
                instance.pause = true;
                myparticles.Play();
                
            }


            }

    }

    public static void particlesvertical(int line, Transform[] spaces)
    {
       
            instance.StartCoroutine(instance.spacetime());
        
        /*
        ParticleSystem myparticles;
        if (!instance.pause) {
            instance.pause = true;
            for (int j = 0; j < 8; j++)
                {
            foreach (Transform child in spaces[line].transform)
            {
                // Debug.Log("lineaaaaaaaaaaaaaaaaaaaaa" + j);

                myparticles = spaces[line].GetComponent<ParticleSystem>();
                instance.StartCoroutine(instance.spacetime());

                
                myparticles.Play();


            }
            line += 8;
        }
                }

    }

    IEnumerator spacetime()
    {
        Debug.Log("holaguapo");
        yield return new WaitForSeconds(10f);
        Debug.Log("holaguapoddddddd");
        pause = false;
        
        //spaces[space].GetComponent<space>().empty = true;

    }*/
}
