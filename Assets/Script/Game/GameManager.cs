using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MonsterSpawnManager spawnManager;
    DayManager dayManager;
    GameObject[] btns = new GameObject[4];
    private bool isNight = false;
    void Start()
    {
        spawnManager = GetComponent<MonsterSpawnManager>();
        dayManager = GameObject.Find("Day Bar").GetComponent<DayManager>();
        btns = GameObject.FindGameObjectsWithTag("Button");
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
        BtnEnable(true);
    }

    private void NightEvent()
    {        
        BtnEnable(false);
        MonsterSpawn();
    }

    private void MonsterSpawn(){       
        spawnManager.enableSpwan = true;
        spawnManager.SpawnManage();
        spawnManager.enableSpwan = false;
    }

    private void BtnEnable(bool isEnable){
        for (int i = 0; i < btns.Length; i++) btns[i].SetActive(isEnable);
    }

    void CheckIsClear(){
        bool isClaer;

        if (spawnManager.nowMonsterNumber == 0) isClaer = true;
        else isClaer = false;

        dayManager.SendMessage("SetIsClear", isClaer);
    }
    
    public void GameOver(){

    }
}
