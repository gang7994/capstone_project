using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public float        hp = 1000f;
    
    public GameObject base_health_bar;
    public GameObject base_health_text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base_health_bar.GetComponent<Slider>().value = hp;
        base_health_text.GetComponent<Text>().text = hp.ToString();

        if(hp <= 0) { //체력이 0이하가 되면 게임오버 팝업창이 뜸
            //GameObject.Find("UI").GetComponent<UI>().Gameover_Panel_active();
            print("Game Over!");
        }
    }
}
