using UnityEngine;
using System.Collections;

public class camera_controller : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
	}
}
