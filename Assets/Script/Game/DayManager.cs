using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public GameObject Daylight;
    public Transform Number;    // UI 텍스트
    public GameObject turnNightBtn;
    GameManager GameManager;
    private bool isNight = false;
    Color color;
    public float roundTime = 200f; //밤시간
    private int day = 1;
    private float time;
    private bool isStop;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        GetComponent<Image>().fillAmount = 0;
        time = 0f;
        isStop = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isStop){
            time += Time.fixedDeltaTime;
            GetComponent<Image>().fillAmount += 0.0001f; 
            if (time >= roundTime){
                isStop = true;
                ChangeDay();
            }
        }
    }

    public void ChangeDay()
    {
        isNight = !isNight;
        GetComponent<Image>().fillAmount = 0; 
        if (isNight) // 밤일때
        {
            turnNightBtn.SetActive(false);
            BecomeNight();
            isStop = false;
            Daylight.GetComponent<Light>().color = new Color(0, 0, 0, 255f);
        }
        else // 낮일때
        {
            turnNightBtn.SetActive(true);
            isStop = true;
            time = 0;
            day += 1; 
            Number.GetComponent<Text>().text = day.ToString();      
            Daylight.GetComponent<Light>().color = new Color(255/255f, 244/255f, 214/255f, 255f/255f);;
        }     
        Debug.Log(turnNightBtn.activeSelf);
    }

    void BecomeNight(){
        GameManager.SendMessage("MsgReceive", isNight);
        // send "isNighit=ture" to MonsterSpawnManager.cs 
    }
}
