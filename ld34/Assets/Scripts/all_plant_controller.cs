using UnityEngine;
using System.Collections;

public class all_plant_controller : MonoBehaviour {

	public GameObject plant_section;
    private GameObject platform;
    private level_manager manager;
	private int number_of_sections = 0;
    private int last_water_amount = 0;
    private int last_manure_amount = 0;
    public int max_levels = 0;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("level_manager").GetComponent<level_manager>();
        platform = transform.GetChild(0).gameObject;
    }

	void Update()
	{

        if(manager.get_water_leves() >= last_water_amount + 5 && manager.manure_level >= last_manure_amount + 2)
        {
            add_section();
            last_water_amount = manager.get_water_leves();
            last_manure_amount = manager.manure_level;
        }
	}

	public void add_section()
	{
        if (number_of_sections < max_levels)
        {
            GameObject new_plant_section = Instantiate(plant_section);
            Vector3 new_plant_section_position = new_plant_section.transform.position;
            new_plant_section_position.y = this.transform.position.y + (new_plant_section.transform.localScale.y * new_plant_section.GetComponent<SpriteRenderer>().sprite.bounds.size.y) * number_of_sections;
            new_plant_section.transform.position = new_plant_section_position;
            number_of_sections++;
            Vector3 new_position = new_plant_section.transform.position;
            new_position.y += new_plant_section.GetComponent<Renderer>().bounds.size.y / 2;
            platform.transform.position = new_position;
            new_plant_section.transform.parent = this.gameObject.transform;
        }
	}
}
