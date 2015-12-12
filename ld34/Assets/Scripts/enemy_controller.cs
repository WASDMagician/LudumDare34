using UnityEngine;
using System.Collections;

public class enemy_controller : MonoBehaviour {

    int direction = -1;
    int speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
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
            Move();
        }
    }
}
