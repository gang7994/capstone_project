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
    private bool isNight = false;
    private int monsterNum = 0;
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
        //InvokeRepeating("MonsterSpawn", 10, 10);
    }

    void SetIsNight(bool isNight){
        this.isNight = isNight;

        if (this.isNight == true) NightEvent();
        else DayEvent();
    }

    private void DayEvent()
    {
        UIEnable(true);
    }

    private void NightEvent()
    {        
        UIEnable(false);
        MonsterSpawn();
    }

    private void MonsterSpawn(){    
        spawnManager.StartCoroutine("SpawnManage");
    }

    private void UIEnable(bool isEnable){
        for (int i = 0; i < btns.Length; i++) btns[i].SetActive(isEnable);
        monsterAmountText.SetActive(!isEnable);
    }

    void CheckIsClear(){
        bool isClaer;

        if (this.monsterNum == 0) isClaer = true;
        else isClaer = false;

        dayManager.SendMessage("SetIsClear", isClaer);
    }

    public void ChangeMonsterNumText(int monsterNumber){
        this.monsterNum += monsterNumber;
        monsterAmount.GetComponent<TextMeshProUGUI>().text = this.monsterNum.ToString();
    }
    
    public void GameOver(){

    }
}
