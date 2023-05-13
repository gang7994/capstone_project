using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    MonsterSpawnManager spawnManager;
    DayManager dayManager;
    GameObject[] btns = new GameObject[4];
    GameObject monsterAmountText;
    GameObject monsterAmount;
    public GameObject moneyText1;
    public GameObject moneyText2;
    public int money = 1000;
    

    private bool isNight = false;
    private int monsterNum = 0;
    private int day = 1;
    void Start()
    {
        spawnManager = GetComponent<MonsterSpawnManager>();
        dayManager = GameObject.Find("Day Bar").GetComponent<DayManager>();
        btns = GameObject.FindGameObjectsWithTag("Button");
        monsterAmountText = GameObject.Find("MonsterAmountText");
        monsterAmount = GameObject.Find("MonsterAmount");
        monsterAmountText.SetActive(false);
    }

    void Update(){
        moneyText1.GetComponent<TextMeshProUGUI>().text = money.ToString();
        moneyText2.GetComponent<TextMeshProUGUI>().text = money.ToString();

    }

    void SetIsNight(bool isNight){
        this.isNight = isNight;

        if (this.isNight == true) NightEvent();
        else DayEvent();
    }

    private void DayEvent()
    {
        day += 1;
        Debug.Log("now day is " + day);
        UIEnable(true);
    }

    private void NightEvent()
    {        
        UIEnable(false);
        MonsterSpawn();
    }

    private void MonsterSpawn(){    
        spawnManager.StartCoroutine("SpawnManage", day);
    }

    private void UIEnable(bool isEnable){
        for (int i = 0; i < btns.Length; i++) btns[i].SetActive(isEnable);
        monsterAmountText.SetActive(!isEnable);
    }

    private void CheckIsClear(){
        bool isClaer;

        if (this.monsterNum == 0) isClaer = true;
        else isClaer = false;

        dayManager.SendMessage("SetIsClear", isClaer);
    }

    public void ChangeMonsterNumText(int monsterNumber){
        this.monsterNum += monsterNumber;
        monsterAmount.GetComponent<TextMeshProUGUI>().text = this.monsterNum.ToString();

        if (this.monsterNum <= 0) CheckIsClear();
    }
    
    public void GameOver(){
        // need implementation
    }

    public void Exit(){
        Application.Quit();
    }
}
