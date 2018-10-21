using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KijGolfowyPlebEdition : MonoBehaviour {

    float TheForce = 100.0f;
	// Use this for initialization
	void Start () {
        GetComponent<ConstantForce>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButton("Fire1") && TheForce <2500.0f)
        {
            TheForce += 50f;
            // GetComponent<ConstantForce>().enabled = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //GetComponent<ConstantForce>().enabled = true;
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, -TheForce);
            Debug.Log("Ball launched at " + TheForce + " power.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GolfBall")
        {
            GameObject foo;
            foo = transform.parent.gameObject;
            transform.parent = null;
            Destroy(foo);
            Destroy(gameObject);
        }
    }
}
