using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public GameObject Daylight;
    public Transform Number;    // UI 텍스트
    GameManager GameManager;
    private bool isNight = false;
    Color color;
    /* Night Round Time */
    float roundTime = 100f; 
    /* Fixed Update Period, Unity Project Settings > Time > Fixed Timestep value */
    float fixedUpdateTime = 0.02f; 
    /* 
     *  UI fillAmount Value 
     *  fillValue = fixedUpdateTime / roundTime
    */
    private float fillValue = 0.0002f; 
    /* Now Time Value */
    private float time = 0f;
    private int day = 1;
    private bool isStop = true;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isStop){
            time += Time.fixedDeltaTime;
            GetComponent<Image>().fillAmount += (float)fillValue; 
            if (time >= roundTime){
                isStop = true;
                time = 0f;
                ChangeDay();
            }
        }
    }

    public void ChangeDay()
    {
        isNight = !isNight;
        SetDayOrNight();
        GetComponent<Image>().fillAmount = 0; 
        if (isNight) // 밤일때
        {
            isStop = false;
            Daylight.GetComponent<Light>().color = new Color(0, 0, 0, 255f);
        }
        else // 낮일때
        {
            isStop = true;
            time = 0;
            day += 1; 
            Number.GetComponent<Text>().text = day.ToString();      
            Daylight.GetComponent<Light>().color = new Color(255/255f, 244/255f, 214/255f, 255f/255f);;
        }     
    }

    void SetDayOrNight(){
        GameManager.SendMessage("MsgReceive", isNight);
        // send "isNighit=ture" to MonsterSpawnManager.cs 
    }
}
