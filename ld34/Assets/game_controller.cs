using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class game_controller : MonoBehaviour {

    public Text time_text;
	
	// Update is called once per frame
	void Update () {
        Update_Time_Text();
	}

    void Update_Time_Text()
    {
        time_text.text = "Time: " + (int)Time.fixedTime;
    }
}
