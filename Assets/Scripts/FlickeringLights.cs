using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public Light lightSource;
    public AudioSource lightHum;

        void Start()
        {
            
        }

        void Update()
        {
            lightHum.Play();
            /* if ()
            {
                lightSource.enabled = !lightSource.enabled;
            } */
        }
}