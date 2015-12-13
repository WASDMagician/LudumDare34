﻿using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

	public float jumpHeight;
	public float moveSpeed;
	private bool isGrounded = true;

	

	// Use this for initialization
	void Start () 
	{
	
	}

  

	// Update is called once per frame
	void Update () 
	{
        
		if(Input.GetKeyDown(KeyCode.W))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			isGrounded = false;
		}

		Vector3 player_position = transform.position;
		player_position.x += (Input.GetAxis("Horizontal") * Time.deltaTime) * moveSpeed;
		transform.position = player_position;
        if(GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            print("BLAH");
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 10, false);
        }
	}

	public void set_grounded(bool grounded)
	{
		isGrounded = grounded;
	}

	public bool get_grounded()
	{
		return isGrounded;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }
    }
}