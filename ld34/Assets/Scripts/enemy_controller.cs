using UnityEngine;
using System.Collections;

public class enemy_controller : MonoBehaviour {
       
    public int health = 100;
    public GameObject compost;
    int direction = -1;
    int speed = 5;



    private player_controller m_player;
    Vector2 pushBackMinus = new Vector2(-200, 0);
    Vector2 pushBackPositive = new Vector2(200, 0);

    // Use this for initialization
    void Start () {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>();
    }

	
	// Update is called once per frame
	void Update () {
        //Move();
	}

    void Move()
    {
        Vector2 new_position = transform.position;
        new_position.x += (direction * speed) * Time.deltaTime;
        transform.position = new_position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("direction"))
        {
            direction *= -1;
          //  Move();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("PlatformOfDeath"))
        {
            GameObject new_compost = Instantiate(compost);
            new_compost.transform.position = this.transform.position;
            new_compost.transform.parent = new_compost.transform.parent;
            Destroy(this);
        }

        if (col.gameObject.CompareTag("Player"))
        {

            //health -= 25;
            // check_health();
            // direction *= -1;

            if(m_player.moveSpeed <= -1)
            {
                Debug.Log("Hit");
                GetComponent<Rigidbody2D>().AddForce(pushBackMinus);
            }

            if (m_player.moveSpeed >= 1)
            {
                Debug.Log("Hit");
                GetComponent<Rigidbody2D>().AddForce(pushBackPositive);
            }
        }
    }

    void check_health()
    {
        if(health <= 0)
        {
            GameObject new_compost = Instantiate(compost);
            new_compost.transform.position = this.transform.position;
            new_compost.transform.parent = new_compost.transform.parent;
            Destroy(this.gameObject);
        }
    }
}
