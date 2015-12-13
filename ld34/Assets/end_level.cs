using UnityEngine;
using System.Collections;

public class end_level : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        GetComponent<load_next_level>().load();
    }
}
