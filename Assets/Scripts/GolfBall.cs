using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GolfBall : MonoBehaviour {

    public Transform ballstick;
    public bool hasBeenTouched;

    void Stop()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
	// Use this for initialization
	void Start () {
        hasBeenTouched = false;

    }
	
	// Update is called once per frame
	void Update () {

        if(GetComponent<Rigidbody>().velocity.magnitude > 0.5)
        {
            Debug.Log("Rolling");
            hasBeenTouched = true;
        }

        if (hasBeenTouched && GetComponent<Rigidbody>().velocity.magnitude < 1 && GetComponent<Rigidbody>().velocity.magnitude > 0.0)
        {
            Debug.Log("Drop the base");
            Stop();
            Instantiate(ballstick, this.transform.position, new Quaternion(0,0,0,0));
            hasBeenTouched = false;
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Hole")
        {
            Destroy(this);
            Debug.Log("Epic Win!");
            SceneManager.UnloadSceneAsync("Course1");
            SceneManager.LoadScene("Course2");
        }
    }
}
