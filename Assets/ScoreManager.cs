using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoretext;
    public Text Bestscoretext;
    public Button play;
    int score;
    int best;


    // Use this for initialization
    void Start () {
       
       score= PlayerPrefs.GetInt("Score");
        best = PlayerPrefs.GetInt("Best");
        scoretext.text = score.ToString();

        if (PlayerPrefs.GetInt("Best") < score)
        {
            PlayerPrefs.SetInt("Best", best);
            best = PlayerPrefs.GetInt("Best");

        }
        Bestscoretext.text = best.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playAgain() {
        Application.LoadLevel("Game");
    }
}
