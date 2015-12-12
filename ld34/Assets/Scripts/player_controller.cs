using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

	public float speed = 1f;
	private float move = 1f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);
	}

}