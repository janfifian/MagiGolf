using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraTextController : MonoBehaviour {
    public Text cameraText;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (CameraControl.CameraDisabled == true)
        {
            cameraText.text = "Camera OFF";
        }
        else
            cameraText.text = "Camera ON";
	}
}
