using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public GameObject Daylight;
    public GameObject day_text; 
    public GameObject Number; //낮 UI 텍스트
    public GameObject night_text;
    public GameObject night_Number; //남은 시간 UI 텍스트
    public GameObject blizzard;
    private AudioSource[] BGM;
    private AudioSource Day;
    private AudioSource Night;

    GameManager gameManager;
    Tech_Manager tech_manager;
    public bool isNight = false;
    Color color;
    /* Left Time */
    /* Night Round Time */
    float roundTime = 100f;
    /* Left Time */
    float leftTime; 
    /* Fixed Update Period, Unity Project Settings > Time > Fixed Timestep value */
    float fixedUpdateTime = 0.02f; 
    /* 
     *  UI fillAmount Value 
     *  fillValue = fixedUpdateTime / roundTime
     *  Calcurate ony by your hand!! 
     *  소수점 값 4번째자리까지 계산은 손으로만 해야 함!!
    */
    private float fillValue = 0.0002f; 
    /* Now Time Value */
    private float time = 0f;
    private int day = 1;
    private bool isStop = true;
    private bool isClear = false;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        tech_manager = GameObject.Find("TechUI").GetComponent<Tech_Manager>();
        GetComponent<Image>().fillAmount = 0;
        night_text.SetActive(false);
        night_Number.SetActive(false);
        BGM = GameObject.Find("Main Camera").GetComponents<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isStop){
            time += Time.fixedDeltaTime;
            leftTime -= Time.fixedDeltaTime;
            if(GetComponent<Image>().fillAmount!=0) night_Number.GetComponent<Text>().text = $"{(int)leftTime}초";
            GetComponent<Image>().fillAmount += (float)fillValue; 
            if (isClear) {
                isStop = true;
                time = 0f;
                ChangeDay();
                isClear = false;
            }
            if (time >= roundTime){
                isStop = true;
                time = 0f;
                if (isClear) ChangeDay();
                else gameManager.GameOver();
            }
        }
    }

    private void ChangeDay()
    {
        character.GetComponent<Player>().SetValue();
        isNight = !isNight;
        SetDayOrNight();
        GetComponent<Image>().fillAmount = 0; 
        if (isNight) // 밤일때
        {
            
            leftTime = roundTime;
            isStop = false;
            Daylight.GetComponent<Light>().color = new Color(0, 0, 0, 255f);
            night_text.SetActive(true);
            night_Number.SetActive(true);
            
            Number.SetActive(false);
            day_text.SetActive(false);
        }
        else // 낮일때
        {
            
            tech_manager.Tech_Button_Click();
            day += 1; 
            Number.GetComponent<Text>().text = day.ToString();      
            Daylight.GetComponent<Light>().color = new Color(255/255f, 244/255f, 214/255f, 255f/255f);
            night_text.SetActive(false);
            night_Number.SetActive(false);
            
            Number.SetActive(true);
            day_text.SetActive(true);
            blizzard.SetActive(false); 
        }     
        
    }

    private void SetDayOrNight()
    {
        gameManager.SendMessage("SetIsNight", isNight);
    }

    void SetIsClear(bool isClear)
    {
        this.isClear = isClear;
    }

}
