using UnityEngine;
using System.Collections;

public class enemy_spawner : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        Spawn();
	}

    public void Spawn()
    {
        print("Spawn");
        if (Random.Range(1, 3) == 2)
        {
            GameObject new_enemy = Instantiate(enemy);
            Vector2 new_enemy_position = this.transform.position;
            new_enemy_position.y += new_enemy.GetComponent<Renderer>().bounds.extents.y * 2;
            new_enemy.transform.position = new_enemy_position;
            new_enemy.transform.parent = this.transform;
        }
    }
}
