using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public level_manager manager;
    private AudioSource clip;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("level_manager").GetComponent<level_manager>();
        clip = GetComponent<AudioSource>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            manager.update_water_display(5);
            manager.number_of_water_bottles--;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            clip.Play();
            Destroy(gameObject, clip.clip.length);
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
