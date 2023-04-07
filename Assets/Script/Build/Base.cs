using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public float        max_hp = 1000;
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
        check_base();

        if(hp <= 0) { //체력이 0이하가 되면 게임오버 팝업창이 뜸
            //GameObject.Find("UI").GetComponent<UI>().Gameover_Panel_active();
            print("Game Over!");
        }
    }

    public void check_base(){
        GameObject warning = transform.Find("SmokeBright").gameObject;
        GameObject danger1 = transform.Find("SmokeDark").gameObject;
        GameObject danger2 = transform.Find("RedFire").gameObject;

        if(hp > max_hp/2){
            warning.SetActive(false);
            danger1.SetActive(false);
            danger2.SetActive(false);
        }
        else if(hp <= max_hp/2 && hp > max_hp/4){
            warning.SetActive(true);
            danger1.SetActive(false);
            danger2.SetActive(false);
        }
        else{
            warning.SetActive(false);
            danger1.SetActive(true);
            danger2.SetActive(true);
        }
    }
}
