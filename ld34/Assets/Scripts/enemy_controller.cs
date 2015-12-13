using UnityEngine;
using System.Collections;

public class enemy_controller : MonoBehaviour {
    public level_manager manager;
    public int health = 100;
    public GameObject compost;
    int direction = -1;
    int speed = 3;
    bool isAttacking = false;

    private Animator animator;
    private player_controller m_player;
    Vector2 pushBackMinus = new Vector2(-10, -10);
    Vector2 pushBackPositive = new Vector2(10, 10);

    // Use this for initialization
    void Start() {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_controller>();
        animator = this.GetComponent<Animator>();
        manager = GameObject.FindGameObjectWithTag("level_manager").GetComponent<level_manager>();
    }


    // Update is called once per frame
    void Update() {

        Move();

        if (direction == 0)
        {
            animator.SetInteger("Enemy_Anim_List", 0);
        }
        if (direction > 0)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                animator.SetInteger("Enemy_Anim_List", 1);
            }
        }
        else if (direction < 0)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                animator.SetInteger("Enemy_Anim_List", 1);
            }
        }
        if(Vector3.Distance(m_player.transform.position, transform.position) < 1)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        if(isAttacking == true)
        {
            animator.SetInteger("Enemy_Anim_List", 3);
        }
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

    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("PlatformOfDeath"))
        {
            GameObject new_compost = Instantiate(compost);
            new_compost.transform.position = this.transform.position;
            new_compost.transform.parent = new_compost.transform.parent;
            manager.numeber_of_enemies--;
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            print(m_player.transform.localScale.x.ToString() + " " + m_player.isAttacking);

            if (m_player.isAttacking)
            {
                if (m_player.transform.localScale.x <= 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(pushBackMinus, ForceMode2D.Impulse);
                }

                if (m_player.transform.localScale.x >= 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(pushBackPositive, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (isAttacking)
                {
                    if (transform.localScale.x <= 0)
                    {
                        m_player.GetComponent<Rigidbody2D>().AddForce(pushBackMinus, ForceMode2D.Impulse);
                    }
                    else
                    {
                        m_player.GetComponent<Rigidbody2D>().AddForce(pushBackPositive, ForceMode2D.Impulse);
                    }
                }
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
