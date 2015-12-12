using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            level_manager.water_level += 5;
            Debug.Log(level_manager.water_level);
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
