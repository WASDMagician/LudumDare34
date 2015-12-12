using UnityEngine;
using System.Collections;

public class water_spawner : MonoBehaviour {

    public GameObject water_bottle;

	// Use this for initialization
	void Start () {
        if (Random.Range(1, 3) == 2)
        {
            Instantiate(water_bottle);
        }
	}
}
