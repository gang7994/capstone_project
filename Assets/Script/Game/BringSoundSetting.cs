using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BringSoundSetting : MonoBehaviour
{
    public GameObject Slider_m, Slider_b, Slider_s;
    public float master = 1.0f;
    public float bgm = 1.0f;
    public float sfx = 1.0f;
    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }

    // Update is called once per frame
    void Update()
    {
        if(Slider_m!= null&&Slider_b!=null&&Slider_s!=null){
            master = Slider_m.GetComponent<Slider>().value;
            bgm = Slider_b.GetComponent<Slider>().value;   
            sfx = Slider_s.GetComponent<Slider>().value; 
        }
    }
}
