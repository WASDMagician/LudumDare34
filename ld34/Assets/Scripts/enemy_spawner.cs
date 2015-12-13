using UnityEngine;
using System.Collections;

public class enemy_spawner : MonoBehaviour {
    public level_manager manager;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("level_manager").GetComponent<level_manager>();
        Spawn();
	}

    public void Spawn()
    {
        if (Random.Range(1, 3) == 2)
        {
            GameObject new_enemy = Instantiate(enemy);
            Vector2 new_enemy_position = this.transform.position;
            new_enemy_position.y += new_enemy.GetComponent<Renderer>().bounds.extents.y * 2;
            new_enemy.transform.position = new_enemy_position;
            new_enemy.transform.parent = this.transform;
            manager.numeber_of_enemies++;
        }
    }

    public void Spawn(bool spawn)
    {
        GameObject new_enemy = Instantiate(enemy);
        Vector2 new_enemy_position = this.transform.position;
        new_enemy_position.y += new_enemy.GetComponent<Renderer>().bounds.extents.y * 2;
        new_enemy.transform.position = new_enemy_position;
        new_enemy.transform.parent = this.transform;
        manager.numeber_of_enemies++;
    }
}
