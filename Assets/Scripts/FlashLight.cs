using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light flashlight;
    public AudioSource turnOff;
    public AudioSource turnOn;

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (flashlight.enabled == true){
                    turnOff.Play();
                } else {
                    turnOn.Play();
                }
                flashlight.enabled = !flashlight.enabled;
            }
        }
}

