using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class level_manager : MonoBehaviour {

	

	public GameObject platform_part;
	int min_x, max_x, min_y, max_y, deadzone_min_x, deadzone_max_x, platform_y_distance, last_y_position;
    
	public int water_level;
	public Text water_level_display;

	public List<GameObject> platforms;

    public int numeber_of_enemies = 0;
	public int number_of_water_bottles = 0;
	
	// Use this for initialization
	void Start () {
		min_x = -5;
		max_x = 5;
		min_y = 0;
		max_y = 50;
		deadzone_min_x = -1;
		deadzone_max_x = 1;
		platform_y_distance = 4;
		last_y_position = -2;
		water_level = 0;

		for(int i = 0; i < 50; i++)
		{
			add_platform();
		}
	}

	void Update()
	{
		if(number_of_water_bottles <= 1)
		{
			update_water_bottles();
		}

        if(numeber_of_enemies <= 3)
        {
            update_enemies();
        }
	}

	void update_water_bottles()
	{
		for(int i = 0; i < platforms.Count; i++)
		{
			platforms[i].GetComponent<water_spawner>().Spawn();
		}
	}

    void update_enemies()
    {
        print("Respawn");
        for(int i = 0; i< platforms.Count; i++)
        {
            platforms[i].GetComponent<enemy_spawner>().Spawn();
        }
    }

	void add_platform()
	{
		GameObject new_platform = Instantiate(platform_part);
		Vector3 new_platform_position = new_platform.transform.position;
		new_platform.transform.localScale = new Vector3(Random.Range(1.5f, 4), 1, 1);
		if (Random.Range(1, 3) == 2)
		{
			new_platform_position.x = Random.Range(min_x + new_platform.GetComponent<SpriteRenderer>().bounds.size.x / 2, deadzone_min_x);
		}
		else
		{
			new_platform_position.x = Random.Range(deadzone_max_x, max_x - new_platform.GetComponent<SpriteRenderer>().bounds.size.x / 2);
		}
		new_platform_position.y = last_y_position + platform_y_distance;
		last_y_position = (int)new_platform_position.y;
		new_platform.transform.position = new_platform_position;
		new_platform.transform.parent = this.transform;
		
		platforms.Add(new_platform);
		
	}

	public void update_water_display(int water_amount)
	{
		water_level += water_amount;
		//water_level_display.text = "Water Level: " + water_amount.ToString();
		
	}

	public int get_water_leves()
	{
		return water_level;
	}
}
