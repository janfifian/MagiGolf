using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour {
    public Transform ballTransform;
	// Use this for initialization
	void Start () {
        this.transform.position = ballTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position != ballTransform.position)
            this.transform.position = ballTransform.position;
    }
}
