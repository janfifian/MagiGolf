using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform ballposition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey("q"))
        {
            transform.Translate(0, 0.5f, 0);
        }
        if (Input.GetKey("e"))
        {
            transform.Translate(0, -0.5f, 0);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(0.5f, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-0.5f, 0, 0);
        }
        if (Input.GetKey("r"))
        {
            transform.Translate(0, 0, 0.5f);
        }
        if (Input.GetKey("f"))
        {
            transform.Translate(0, 0, -0.5f);
        }
        GetComponent<Rigidbody>().velocity = new Vector3 (0.0f, 0.0f, ballposition.GetComponent<Rigidbody>().velocity.z);

    }
}
