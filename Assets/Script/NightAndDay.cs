using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightAndDay : MonoBehaviour
{
    public GameObject Daylight;
    bool night = false;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().fillAmount = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDay()
    {
        
        if (GetComponent<Image>().fillAmount < 1)
        {
            if (night)
            {
                Daylight.GetComponent<Light>().color = new Color(255/255f, 244/255f, 214/255f, 255f/255f);;
                GetComponent<Image>().fillAmount += 0.01f;
                night = false;
            }
            else
            {

                Daylight.GetComponent<Light>().color = new Color(0, 0, 0, 255f);
                night = true;
            }
            
        }
    }
}
