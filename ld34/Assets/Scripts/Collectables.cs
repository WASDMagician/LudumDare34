using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public level_manager manager;

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
            manager.number_of_water_bottles--;
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
