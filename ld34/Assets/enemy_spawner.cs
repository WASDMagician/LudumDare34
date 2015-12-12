using UnityEngine;
using System.Collections;

public class enemy_spawner : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
	    if(Random.Range(1, 3) == 2)
        {
            Instantiate(enemy);
        }
	}
	
	
}
