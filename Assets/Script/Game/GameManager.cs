using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MonsterSpawnManager spawnManager;
    DayManager dayManager;
    GameObject[] btns = new GameObject[4];
    private bool nowIsNight = false;
    void Start()
    {
        spawnManager = GetComponent<MonsterSpawnManager>();
        dayManager = GameObject.Find("Day Bar").GetComponent<DayManager>();
        btns = GameObject.FindGameObjectsWithTag("Button");
    }
    void Update(){
        //InvokeRepeating("MonsterSpawn", 10, 10);
    }
    public void MsgReceive(bool isNight){
        nowIsNight = isNight;
        if (nowIsNight == true) NightEvent();
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
}
