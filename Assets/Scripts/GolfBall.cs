﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GolfBall : MonoBehaviour {

    public Transform ballstick;
    public bool hasBeenTouched;
    public Text displayComponent;
    private int count;
    void Stop()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
	// Use this for initialization
	void Start () {
        Instantiate(ballstick, this.transform.position, new Quaternion(0, 0, 0, 0));
        hasBeenTouched = false;
        count = 0;
        SetCounterText();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(GetComponent<Rigidbody>().velocity.magnitude > 0.5)
        {
        //    Debug.Log("Rolling");
            hasBeenTouched = true;
        }

        if (hasBeenTouched && GetComponent<Rigidbody>().velocity.magnitude < 1 && GetComponent<Rigidbody>().velocity.magnitude > 0.0)
        {
        //    Debug.Log("Drop the base");
            Stop();
            Instantiate(ballstick, this.transform.position, new Quaternion(0,0,0,0));
            hasBeenTouched = false;
            count++;
            SetCounterText();
        }

        if (Input.GetKeyDown("k"))
        {
            EndCourse();
        }
	}

    private void SetCounterText()
    {
        displayComponent.text = "Hits so far: " + count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Hole")
        {
            EndCourse();
        }

    }
    IEnumerator delayedLoad()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Loading Course No 2");
        SceneManager.LoadSceneAsync("Course2");
    }
    void EndCourse()
    {
        StartCoroutine(delayedLoad());
        Debug.Log("Epic Win!");
    }
}
