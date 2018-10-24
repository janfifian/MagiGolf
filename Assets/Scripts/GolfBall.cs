using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GolfBall : MonoBehaviour {

    public bool hasBeenTouched;
    public Text displayComponent;
    public Slider H_Slider;
    public Slider V_Slider;
    public Rigidbody rb;
    public float MaxPower;

    private int counter;
    private int count;
    private float percentageOfHPower;
    private float percentageOfVPower;
    // Use this for initialization
    void Start () {
        hasBeenTouched = false;
        count = 0;
        SetCounterText();
        counter = 0;
    }
	
	// Update is called once per frame
	void Update()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            H_Slider.GetComponent<SliderMovement>().Enable();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                counter++;
            }
            if (counter == 1)
            {
                H_Slider.GetComponent<SliderMovement>().isEnabled = false;
                percentageOfHPower = H_Slider.value;
                V_Slider.GetComponent<SliderMovement>().Enable();
            }
            
            if (counter == 2)
            {
                V_Slider.GetComponent<SliderMovement>().isEnabled = false;
                percentageOfVPower = V_Slider.value;
            }

            if (counter == 3)
            {
                
                rb.AddForce(Camera.main.transform.forward.x * MaxPower * percentageOfHPower,
                    Camera.main.transform.forward.y * MaxPower * percentageOfVPower, 
                    Camera.main.transform.forward.z * MaxPower * percentageOfHPower);
                counter = 0;
            }
        }
        if (GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            H_Slider.GetComponent<SliderMovement>().Disable();
            V_Slider.GetComponent<SliderMovement>().Disable();
            H_Slider.GetComponent<SliderMovement>().isEnabled = true;
            V_Slider.GetComponent<SliderMovement>().isEnabled = true;
        }
        

        //if (GetComponent<Rigidbody>().velocity.magnitude > 0.5)
        //{
        //    hasBeenTouched = true;
        //}

        //if (hasBeenTouched && GetComponent<Rigidbody>().velocity.magnitude < 1 && GetComponent<Rigidbody>().velocity.magnitude > 0.0)
        //{
        ////    Debug.Log("Drop the base");
        //    hasBeenTouched = false;
        //    count++;
        //    SetCounterText();
        //}

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
