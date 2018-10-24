using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMovement : MonoBehaviour {

    public bool isEnabled = true;
    public float speed = 2;
    private Slider slider;
	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        slider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isEnabled)
        {
            //Debug.Log((Mathf.Sin(Time.time * speed) + 1) / 2);
            float sinusArgument = (Mathf.Sin(Time.time * speed) + 1) / 2;
            slider.value = sinusArgument;
        }
    }

    public void Enable()
    {
        slider.gameObject.SetActive(true);
    }

    public void Disable()
    {
        slider.gameObject.SetActive(false);
    }
}
