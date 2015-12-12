using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    level_manager manager;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("level_manager").GetComponent<level_manager>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            manager.update_water_display(5);
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
