using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowControl : MonoBehaviour
{
    public GameObject TopCamera;


    void Start()
    {
        
      

    }

    // Update is called once per frame
    void Update()
    {
        if(TopCamera.activeSelf == true)
        {
            ShadowOff();
        }
        else
        {
            ShadowOn();
        }
    }

    void ShadowOff()
    {
        Light light = GetComponent<Light>();
        light.shadowStrength = 0;
    }
    void ShadowOn()
    {
        Light light = GetComponent<Light>();
        light.shadowStrength = 1;
    }
}
