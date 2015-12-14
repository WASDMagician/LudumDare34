using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highscore : MonoBehaviour {

    public Text highscore_text;

	// Use this for initialization
	void Start () 
    {
        //check keys
        if(!PlayerPrefs.HasKey("highscore"))
        {
            print("Setting highscore to 0");
            PlayerPrefs.SetInt("highscore", 0);
        }
        if(!PlayerPrefs.HasKey("current_score"))
        {
            print("Setting current score to 0");
            PlayerPrefs.SetInt("current_score", 0);
        }

        print("Highscore: " + PlayerPrefs.GetInt("highscore").ToString() + " Current score: " + PlayerPrefs.GetInt("current_score"));

        if(PlayerPrefs.GetInt("current_score") > PlayerPrefs.GetInt("highscore"))
        {
            print("New highscore");
            PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("current_score"));
        }

        highscore_text.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
        highscore_text.text += "\nCurrent Score: " + PlayerPrefs.GetInt("current_score");
        if(PlayerPrefs.GetInt("highscore") <= PlayerPrefs.GetInt("current_score"))
        {
            highscore_text.text += "\nNew highscore!";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
