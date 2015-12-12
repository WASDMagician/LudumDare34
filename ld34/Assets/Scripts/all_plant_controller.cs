using UnityEngine;
using System.Collections;

public class all_plant_controller : MonoBehaviour {

	public GameObject plant_section;
    private level_manager water;
	private int number_of_sections = 0;

    void Start()
    {
        water = GameObject.FindGameObjectWithTag("level_manager").GetComponent<level_manager>();
    }

	void Update()
	{
        if (Input.GetKeyUp(KeyCode.Space))
        {
            add_section();
        }

        if(water.get_water_leves() == 5)
        {
            add_section();
        }
	}

	public void add_section()
	{
		GameObject new_plant_section = Instantiate(plant_section);
		Vector3 new_plant_section_position = new_plant_section.transform.position;
		new_plant_section_position.y = this.transform.position.y + (new_plant_section.transform.localScale.y * new_plant_section.GetComponent<SpriteRenderer>().sprite.bounds.size.y) * number_of_sections;
		new_plant_section.transform.position = new_plant_section_position;
		number_of_sections++;
        new_plant_section.transform.parent = this.gameObject.transform;
	}
}
