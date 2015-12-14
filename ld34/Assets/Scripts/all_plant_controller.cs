using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class all_plant_controller : MonoBehaviour {

	public GameObject plant_section;
    private GameObject platform;
    private level_manager manager;
	private int number_of_sections = 0;
    private int last_water_amount = 0;
    private int last_manure_amount = 0;
    public int max_levels = 0;
    private int required_water = 5;
    private int required_compost = 3;

    public Text required_amounts;

    AudioSource growing;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("level_manager").GetComponent<level_manager>();
        platform = transform.GetChild(0).gameObject;
        growing = GetComponent<AudioSource>();
        platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
    }

	void Update()
	{
        
        if(manager.get_water_leves() >= required_water && manager.manure_level >= required_compost)
        {
            
            add_section();
            last_water_amount = manager.get_water_leves();
            last_manure_amount = manager.manure_level;
            manager.water_level = 0;
            manager.manure_level = 0;
            manager.randomize_platforms();
        }
        if(number_of_sections == 6)
        {
            platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            platform.GetComponent<BoxCollider2D>().enabled = true;
        }
        Update_Stats();
	}

    void Update_Stats()
    {
        if (number_of_sections < 6)
        {
            if (manager.water_level < required_water)
            {
                required_amounts.text = "Water: " + manager.water_level.ToString() + "/" + required_water.ToString() + "\n";
            }
            else
            {
                required_amounts.text = "Water: " + required_water.ToString() + "/" + required_water.ToString() + "\n";
            }
            if (manager.manure_level < required_compost)
            {
                required_amounts.text += "Compost: " + manager.manure_level.ToString() + "/" + required_compost.ToString();
            }
            else
            {
                required_amounts.text += "Compost: " + required_compost.ToString() + "/" + required_compost.ToString();
            }
        }
        else
        {
            required_amounts.text = "Water: -/- \nCompost: -/-";
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
            platform.GetComponent<platform_controller>().target = new_position;
            new_plant_section.transform.parent = this.gameObject.transform;
            growing.Play();
        }
	}
}
