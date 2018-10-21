using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

    void Stop()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( GetComponent<Rigidbody>().velocity.magnitude < 0.3) { Stop(); }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Hole")
        {
            Destroy(gameObject);
            Debug.Log("Epic Win!");
        }
    }
}
