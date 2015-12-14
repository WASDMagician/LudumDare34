using UnityEngine;
using System.Collections;

public class platform_controller : MonoBehaviour {
    public Vector3 target;
	// Use this for initialization
	void Start () {
        target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Move_To_Target();
	}

    void Move_To_Target()
    {
        print("Moving");
        Vector3 current_target = Vector3.MoveTowards(transform.position, target, 0.1f);
        transform.position = current_target;
    }
}
