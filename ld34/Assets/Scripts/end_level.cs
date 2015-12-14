using UnityEngine;
using System.Collections;

public class end_level : MonoBehaviour {

    public game_controller controller;

    int finish_time;

	void OnTriggerEnter2D(Collider2D col)
    {
        finish_time = (int)Time.fixedTime;
        PlayerPrefs.SetInt("current_score", finish_time);
        GetComponent<load_next_level>().load();
    }
}
