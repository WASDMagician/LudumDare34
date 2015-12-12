using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void onTriggerEnter2D(Collision2D col)
    {

        Debug.Log("Has Collided");
        if (col.gameObject.name == "Player")
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update () {
      
    }
}
