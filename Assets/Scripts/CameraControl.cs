using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    float minFov = 15f;
    float maxFov = 90f;
    float sensitivity = 10f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    public Transform ballposition;
	// Use this for initialization
	void Start () {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        Debug.Log("Obraca się myszą, kliknięcie strzela, A-D rotacja kija, R-F przód tył");
    }
	
	// Update is called once per frame
	void Update () {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        /*
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
        
        */
        if (Input.GetKey("r"))
        {
            transform.Translate(0, 0, 0.5f);
        }
        if (Input.GetKey("f"))
        {
            transform.Translate(0, 0, -0.5f);
        }
        GetComponent<Rigidbody>().velocity = new Vector3 (0.0f, 0.0f, ballposition.GetComponent<Rigidbody>().velocity.z);
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}