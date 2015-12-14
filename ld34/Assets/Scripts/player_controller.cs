using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

	public float jumpHeight;
	public float moveSpeed;
	public bool isAttacking;
	private bool isGrounded = true;
	private Animator animator;
	private AudioSource source;


	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		source = GetComponent<AudioSource>();
	}



	// Update is called once per frame
	void Update () 
	{
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		if (horizontal == 0)
		{
			animator.SetInteger("Animation_List", 0);
		}
		if (horizontal > 0)
		{
			if (transform.localScale.x < 0)
			{
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				animator.SetInteger("Animation_List", 1);
				isAttacking = false;
			}
		}
		else if (horizontal < 0)
		{
			if (transform.localScale.x > 0)
			{
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				animator.SetInteger("Animation_List", 1);
				isAttacking = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Space) && (isGrounded == true))
		{            
			animator.SetInteger("Animation_List", 2);
			isAttacking = true;
		 }
		if (Input.GetKeyDown(KeyCode.W) && (isGrounded == true))
		{
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 15, 0), ForceMode2D.Impulse);
			isGrounded = false;
		}

        if(GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
        

		Vector3 player_position = transform.position;
		player_position.x += (Input.GetAxis("Horizontal") * Time.deltaTime) * moveSpeed;
		transform.position = player_position;
		if(GetComponent<Rigidbody2D>().velocity.y > 0)
		{
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

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Enemy"))
		{
            if (!source.isPlaying)
            {
                source.Play();
            }
		}   
	}
}