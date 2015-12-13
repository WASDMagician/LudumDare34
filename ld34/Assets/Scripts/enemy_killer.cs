using UnityEngine;
using System.Collections;

public class enemy_killer : MonoBehaviour {

    // Use this for initialization
    void Start() {
        
    }
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlatformOfDeath")
        {
            Destroy(this);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
