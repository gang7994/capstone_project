using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    MonsterSpawnManager spawnManager;
    DayManager dayManager;
    void Start()
    {
        spawnManager = GetComponent<MonsterSpawnManager>();
        dayManager = GameObject.Find("Day Bar").GetComponent<DayManager>();
        //spawnManager.SpawnManage();
    }
    void Update(){
        //InvokeRepeating("MonsterSpawn", 10, 10);
    }
    public void MonsterSpawn(){
        if (dayManager.isNight == true){
            spawnManager.enableSpwan = true;
            spawnManager.SpawnManage();
            spawnManager.enableSpwan = false;
        }
    }
}
