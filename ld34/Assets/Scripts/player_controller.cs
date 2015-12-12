using UnityEngine;
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

        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

    }

}