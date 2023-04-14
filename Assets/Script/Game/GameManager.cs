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
        BtnDisable();
        MonsterSpawn();
    }
    private void MonsterSpawn(){
        if (nowIsNight == true){
            spawnManager.enableSpwan = true;
            spawnManager.SpawnManage();
            spawnManager.enableSpwan = false;
        }
    }
    private void BtnDisable(){
        if (nowIsNight == true)
        {
            for (int i = 0; i < 4; i++)
            {
                btns[i].SetActive(false);
            }
        }
    }
}
