 using UnityEngine;
using System.Collections;

public class water_spawner : MonoBehaviour {
    public level_manager manager;
    public GameObject water_bottle;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("level_manager").GetComponent<level_manager>();
        Spawn();
	}

    public void Spawn()
    {
        if (Random.Range(1, 3) == 2)
        {
            GameObject new_water_bottle = Instantiate(water_bottle);
            Vector2 water_bottle_position = this.transform.position;
            water_bottle_position.y += new_water_bottle.GetComponent<Renderer>().bounds.extents.y;
            new_water_bottle.transform.position = water_bottle_position;
            new_water_bottle.transform.parent = this.transform;
            manager.number_of_water_bottles++;      
        }
    }
}
