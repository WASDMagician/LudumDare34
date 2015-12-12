using UnityEngine;
using System.Collections;

public class load_next_level : MonoBehaviour {

    public void load()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
