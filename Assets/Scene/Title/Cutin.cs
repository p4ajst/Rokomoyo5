using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.1f, 0, 0);
        if (transform.position.x < -13.8f)
        {
            transform.position = new Vector3(13.8f, 0, 0);
        }
    }
}
